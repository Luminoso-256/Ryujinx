using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Ipc;
using Ryujinx.HLE.HOS.Kernel.Common;
using System;

namespace Ryujinx.HLE.HOS.Services.Am.AppletAE.AllSystemAppletProxiesService.SystemAppletProxy
{
    class IGlobalStateController : IpcService
    {
        public IGlobalStateController() { }
        private int _evHandle;

        [CommandHipc(2)]
        public ResultCode StartSleepSequence(ServiceCtx ctx)
        {
            //ohno
            Logger.Info?.Print(LogClass.ServiceAm, "StartSleepSequence() called");
            return ResultCode.Success;
        }

        [CommandHipc(15)]
        public ResultCode GetHdcpAuthenticationFailedEvent(ServiceCtx ctx)
        {
            if (_evHandle == 0)
            {
                if (ctx.Process.HandleTable.GenerateHandle(ctx.Device.System.GenericPlaceholderEvent.ReadableEvent, out _evHandle) != KernelResult.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }

            ctx.Response.HandleDesc = IpcHandleDesc.MakeCopy(_evHandle);

            Logger.Stub?.PrintStub(LogClass.ServiceAm);

            return ResultCode.Success;
        }
    }
}