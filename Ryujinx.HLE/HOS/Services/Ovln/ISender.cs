using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Ovln
{
    internal class ISender : IpcService
    {
        public ISender(ServiceCtx context) { }

        [CommandHipc(0)]
        public ResultCode send(ServiceCtx ctx)
        {
            return ResultCode.Success;
        }
        [CommandHipc(1)]
        public ResultCode GetUnrecievedMessageCount(ServiceCtx ctx)
        {
            ctx.ResponseData.Write(0);
            return ResultCode.Success;
        }
    }
}
