using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Ipc;
using Ryujinx.HLE.HOS.Kernel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.News
{
    internal class INewsDataService : IpcService
    {
        public INewsDataService(ServiceCtx context) { }

        private int _evHandle;

        [CommandHipc(0)]
        public ResultCode Get(ServiceCtx ctx)
        {
            if (_evHandle == 0)
            {
                if (ctx.Process.HandleTable.GenerateHandle(ctx.Device.System.NewsGetEvent.ReadableEvent, out _evHandle) != KernelResult.Success)
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
