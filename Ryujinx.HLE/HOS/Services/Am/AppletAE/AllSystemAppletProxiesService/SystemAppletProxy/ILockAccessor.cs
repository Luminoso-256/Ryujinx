using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Ipc;
using Ryujinx.HLE.HOS.Kernel.Common;
using Ryujinx.HLE.HOS.Kernel.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Am.AppletAE.AllSystemAppletProxiesService.SystemAppletProxy
{
    internal class ILockAccessor : IpcService
    {
        private UInt32 _inpButton;
       // private KEvent _lockEvent;
        private int _lockEventHandle;
        private bool _locked;
        public ILockAccessor(ServiceCtx context, UInt32 inpButton)
        {
            _inpButton = inpButton;
          //  _lockEvent = new KEvent(context.Device.System.KernelContext);
            _lockEventHandle = -1;
            _locked = false;
        }

        [CommandHipc(1)]
        public ResultCode TryLock(ServiceCtx ctx)
        {
         
            _locked = true;
            //according to https://switchbrew.org/wiki/Applet_Manager_services#ILockAccessor, input flag controls handle, output flag is success
            ctx.ResponseData.Write(true); // here in ryu-stub-land, requests *never fail*!
            bool flag = ctx.RequestData.ReadBoolean();
            Logger.Info?.Print(LogClass.ServiceAm, $"TryLock {flag}");
            if (flag)
            {
                if (_lockEventHandle == -1)
                {
                    KernelResult resultCode = ctx.Process.HandleTable.GenerateHandle(ctx.Device.System.LockedButtonHomeMenuEvent.ReadableEvent, out _lockEventHandle);

                    if (resultCode != KernelResult.Success)
                    {
                        return (ResultCode)resultCode;
                    }
                }
                ctx.Response.HandleDesc = IpcHandleDesc.MakeCopy(_lockEventHandle);
            }
            return ResultCode.Success;
        }

        [CommandHipc(2)]
        public ResultCode Unlock(ServiceCtx ctx)
        {
            Logger.Info?.Print(LogClass.ServiceAm, "Unlock");
            _locked = false;
            return ResultCode.Success;
        }

        [CommandHipc(3)]
        public ResultCode GetEvent(ServiceCtx ctx)
        {
            Logger.Info?.Print(LogClass.ServiceAm, $"GetEvent on ILockAccessor! Woo!");
            if (_lockEventHandle == -1)
            {
                KernelResult resultCode = ctx.Process.HandleTable.GenerateHandle(ctx.Device.System.LockedButtonHomeMenuEvent.ReadableEvent, out _lockEventHandle);

                if (resultCode != KernelResult.Success)
                {
                    return (ResultCode)resultCode;
                }
            }
            ctx.Response.HandleDesc = IpcHandleDesc.MakeCopy(_lockEventHandle);
            Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(500);
                Logger.Info?.Print(LogClass.ServiceAm, "Auto-firing an event w/ delay to bootstrap qlaunch.");
                ctx.Device.System.LockedButtonHomeMenuEvent.ReadableEvent.Signal();
            });
            return ResultCode.Success;
        }

        [CommandHipc(4)]
        public ResultCode IsLocked(ServiceCtx ctx)
        {
            ctx.ResponseData.Write(_locked);
            return ResultCode.Success;
        }
    }
}
