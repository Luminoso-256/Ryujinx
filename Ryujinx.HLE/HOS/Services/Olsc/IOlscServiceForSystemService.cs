namespace Ryujinx.HLE.HOS.Services.Olsc
{
    [Service("olsc:s")] // 4.0.0+
    class IOlscServiceForSystemService : IpcService
    {
        public IOlscServiceForSystemService(ServiceCtx context) { }

        [CommandHipc(0)]
        public ResultCode CreateTaskListController(ServiceCtx ctx)
        {
            MakeObject(ctx, new ITransferTaskListController(ctx));
            return ResultCode.Success;
        }
    }
}