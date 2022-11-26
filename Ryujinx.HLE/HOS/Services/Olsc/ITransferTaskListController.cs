using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Olsc
{
    class ITransferTaskListController : IpcService
    {
        public ITransferTaskListController(ServiceCtx context) { }

        [CommandHipc(0)]
        public ResultCode unk0(ServiceCtx ctx)
        {
            return ResultCode.Success;
        }

        [CommandHipc(5)]
        public ResultCode GetINativeHandleHolder(ServiceCtx ctx)
        {
            MakeObject(ctx,new INativeHandleHolder(ctx));
            return ResultCode.Success;
        }
        [CommandHipc(9)]
        public ResultCode GetINativeHandleHolder_2(ServiceCtx ctx) //help.
        {
            MakeObject(ctx, new INativeHandleHolder(ctx));
            return ResultCode.Success;
        }
    }
}
