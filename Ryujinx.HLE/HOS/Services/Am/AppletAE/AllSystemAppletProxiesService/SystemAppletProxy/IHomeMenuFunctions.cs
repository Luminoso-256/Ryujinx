using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Ipc;
using Ryujinx.HLE.HOS.Kernel.Common;
using Ryujinx.HLE.HOS.Kernel.Threading;
using System;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Am.AppletAE.AllSystemAppletProxiesService.SystemAppletProxy
{
    class IHomeMenuFunctions : IpcService
    {
        private KEvent _channelEvent;
        private int    _channelEventHandle;

        public IHomeMenuFunctions(Horizon system)
        {
            // TODO: Signal this Event somewhere in future.
            _channelEvent = new KEvent(system.KernelContext);
        }

        [CommandHipc(10)]
        // RequestToGetForeground()
        public ResultCode RequestToGetForeground(ServiceCtx context)
        {
            Logger.Stub?.PrintStub(LogClass.ServiceAm);
            return ResultCode.Success;
        }

        [CommandHipc(11)]
        public ResultCode LockForeground(ServiceCtx context)
        {
            return ResultCode.Success;
        }

        [CommandHipc(20)]
        public ResultCode PopFromGeneralChannel(ServiceCtx ctx)
        {
            //https://switchbrew.org/wiki/Applet_Manager_services#PushToGeneralChannel
            //"RequestHomeMenu"
            MakeObject(ctx, new AppletAE.IStorage(new byte[]{0x53,0x41, 0x4d,0x53, 0x01,0x00, 0x00,0x00, 
                /*the magic bit*/ 0x02,0x00, 0x00,0x00, 0x01,0x00, 0x00,0x00}));
            //0x03 ~ starts rendering, black screens
            //0x02 ~ basically the same, except never starts rendering a black screen.
            return ResultCode.Success;
        }

        [CommandHipc(21)]
        // GetPopFromGeneralChannelEvent() -> handle<copy>
        public ResultCode GetPopFromGeneralChannelEvent(ServiceCtx context)
        {
            if (_channelEventHandle == 0)
            {
                if (context.Process.HandleTable.GenerateHandle(_channelEvent.ReadableEvent, out _channelEventHandle) != KernelResult.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }

            context.Response.HandleDesc = IpcHandleDesc.MakeCopy(_channelEventHandle);
            Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(500);
                _channelEvent.ReadableEvent.Signal();
            });

            Logger.Stub?.PrintStub(LogClass.ServiceAm);
            return ResultCode.Success;
        }

        [CommandHipc(30)]
        public ResultCode GetHomeButtonWriterLockAccessorEx(ServiceCtx context)
        {
            MakeObject(context, new ILockAccessor(context, 0));
            return ResultCode.Success;
        }

        [CommandHipc(31)]
        public ResultCode GetWriterLockAccessorEx(ServiceCtx context)
        {
            uint button = context.RequestData.ReadUInt32();
            Logger.Stub?.Print(LogClass.ServiceAm, $"GetWriterLockAccessorEx | Code: {button}");
            // according to switchbrew 0 is home button.
            //they neglect to mention what the others are -_-
            MakeObject(context, new ILockAccessor(context, button));
            return ResultCode.Success;
        }
    }
}