using Ryujinx.HLE.HOS.Ipc;
using Ryujinx.HLE.HOS.Kernel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Am.AppletAE.AllSystemAppletProxiesService.SystemAppletProxy
{
    internal class IApplicationAccessor : IpcService
    {
        public IApplicationAccessor(ServiceCtx context) { }
        private int _appletStateChangedHandle;

        [CommandHipc(0)]
        public ResultCode GetAppletStateChangedEvent(ServiceCtx ctx)
        {
            if (_appletStateChangedHandle == 0)
            {
                if (ctx.Process.HandleTable.GenerateHandle(ctx.Device.System.GenericPlaceholderEvent.ReadableEvent, out _appletStateChangedHandle) != KernelResult.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }

            ctx.Response.HandleDesc = IpcHandleDesc.MakeCopy(_appletStateChangedHandle);
            return ResultCode.Success;
        }

        [CommandHipc(1)]
        public ResultCode IsCompleted(ServiceCtx ctx)
        {
            //sure?
            ctx.ResponseData.Write(true);
            return ResultCode.Success;
        }

        [CommandHipc(101)]
        public ResultCode RequestForApplicationToGetForeground(ServiceCtx ctx)
        {
            return ResultCode.Success;
        }

        [CommandHipc(120)]
        public ResultCode GetApplicationId(ServiceCtx ctx)
        {
            ctx.ResponseData.Write(ctx.Device.Application.TitleId);
            return ResultCode.Success;
        }
    }
}
