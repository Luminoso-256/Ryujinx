namespace Ryujinx.HLE.HOS.Services.News
{
    [Service("news:a")]
    [Service("news:c")]
    [Service("news:m")]
    [Service("news:p")]
    [Service("news:v")]
    class IServiceCreator : IpcService
    {
        public IServiceCreator(ServiceCtx context) { }

        [CommandHipc(0)]
        public ResultCode CreateNewsService(ServiceCtx ctx)
        {
            MakeObject(ctx, new INewsService(ctx));
            return ResultCode.Success;
        }
        [CommandHipc(1)]
        public ResultCode CreateNewlyArrivedEventHolder(ServiceCtx ctx)
        {
            MakeObject(ctx, new INewlyArrivedEventHolder(ctx));
            return ResultCode.Success;
        }
        [CommandHipc(2)]
        public ResultCode CreateNewsDataService(ServiceCtx ctx)
        {
            MakeObject(ctx, new INewsDataService(ctx));
            return ResultCode.Success;
        }
        [CommandHipc(3)]
        public ResultCode CreateNewsDatabaseService(ServiceCtx ctx)
        {
            MakeObject(ctx, new INewsDatabaseService(ctx));
            return ResultCode.Success;
        }
        [CommandHipc(4)]
        public ResultCode CreateOverwriteEventHolder(ServiceCtx ctx)
        {
            MakeObject(ctx, new IOverwriteEventHolder(ctx));
            return ResultCode.Success;
        }


        //== 1.0.0 will be the death of me - these shouldn't be here, but they are. Why? who on earth knows.
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