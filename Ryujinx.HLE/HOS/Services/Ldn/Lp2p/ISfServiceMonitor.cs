using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Ldn.Lp2p
{
    class ISfServiceMonitor : IpcService
    {
        public ISfServiceMonitor(ServiceCtx context) { }

        [CommandHipc(0)]
        public ResultCode Initialize(ServiceCtx ctx)
        {
            return ResultCode.Success;
        }

        [CommandHipc(512)]
        public ResultCode Scan(ServiceCtx ctx)
        {
            ctx.ResponseData.Write(0);
            return ResultCode.Success;
        }

        [CommandHipc(288)]
        public ResultCode GetGroupInfo(ServiceCtx ctx)
        {
            var data = ctx.RequestData.ReadBytes(481);
            ctx.ResponseData.Write(data);
            return ResultCode.Success;
        }
    }
}
