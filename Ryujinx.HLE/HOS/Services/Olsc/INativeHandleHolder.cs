using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Olsc
{
    class INativeHandleHolder : IpcService
    {
        public INativeHandleHolder(ServiceCtx context) { }

        [CommandHipc(0)]
        public ResultCode GetNativeHandle(ServiceCtx ctx)
        {
            //I hope it doesn't mind a zero?
            ctx.ResponseData.Write(0);
            return ResultCode.Success;
        }
    }
}
