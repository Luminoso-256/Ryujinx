using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Ipc;
using Ryujinx.HLE.HOS.Kernel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Notification
{
    internal class INotificationSystemEventAccessor : IpcService
    {
        public INotificationSystemEventAccessor(ServiceCtx context){}
        private int _evHandle;
        [CommandHipc(0)]
        public ResultCode Unk0(ServiceCtx ctx)
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
