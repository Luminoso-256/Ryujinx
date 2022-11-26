using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.News
{
    internal class INewsService : IpcService
    {
        public INewsService(ServiceCtx context) { }

        [CommandHipc(30100)]
        public ResultCode GetSubscriptionStatus(ServiceCtx ctx)
        {
            ctx.ResponseData.Write(0);
            return ResultCode.Success;
        }

        [CommandHipc(30200)]
        public ResultCode IsSystemUpdateRequired(ServiceCtx ctx)
        {
            ctx.ResponseData.Write(false);
            return ResultCode.Success;
        }

        [CommandHipc(0)]
        public ResultCode PostLocalNews(ServiceCtx ctx)
        {
            return ResultCode.Success;
        }
    }
}
