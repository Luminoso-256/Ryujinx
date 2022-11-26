using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Ipc;
using Ryujinx.HLE.HOS.Kernel.Common;
using System;

namespace Ryujinx.HLE.HOS.Services.Ns
{
    [Service("ns:su")]
    class ISystemUpdateInterface : IpcService
    {
        private int _systemUpdateNotificationHandle;
        public ISystemUpdateInterface(ServiceCtx context) { }

        [CommandHipc(9)]
        public ResultCode GetSystemUpdateNotificationEventForContentDelivery(ServiceCtx context) // wow. Apple-like in length.
        {
            if (_systemUpdateNotificationHandle == 0)
            {
                if (context.Process.HandleTable.GenerateHandle(context.Device.System.SystemUpdateNotificationEvent.ReadableEvent, out _systemUpdateNotificationHandle) != KernelResult.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }

            context.Response.HandleDesc = IpcHandleDesc.MakeCopy(_systemUpdateNotificationHandle);

            Logger.Stub?.PrintStub(LogClass.ServiceAm);

            return ResultCode.Success;
        }

        [CommandHipc(10)]
        public ResultCode NotifySystemUpdateForContentDelivery(ServiceCtx ctx)
        {
            ctx.Device.System.SignalSystemUpdateEvent();
            return ResultCode.Success;
        }
    }
}