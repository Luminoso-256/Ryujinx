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
        //== 1.0.0 only ==//


        [CommandHipc(30900)]
        public ResultCode OldCreateNewlyArrivedEventHolder(ServiceCtx ctx)
        {
            MakeObject(ctx, new INewlyArrivedEventHolder(ctx));
            return ResultCode.Success;
        }
        [CommandHipc(30901)]
        public ResultCode OldCreateNewsDataService(ServiceCtx ctx)
        {
            MakeObject(ctx, new INewsDataService(ctx));
            return ResultCode.Success;
        }
        [CommandHipc(30902)]
        public ResultCode OldCreateNewsDatabaseService(ServiceCtx ctx)
        {
            MakeObject(ctx, new INewsDatabaseService(ctx));
            return ResultCode.Success;
        }

       
    }
}
