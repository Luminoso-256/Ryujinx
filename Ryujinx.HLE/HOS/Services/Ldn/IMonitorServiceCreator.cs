namespace Ryujinx.HLE.HOS.Services.Ldn
{
    [Service("ldn:m")]
    class IMonitorServiceCreator : IpcService
    {
        public IMonitorServiceCreator(ServiceCtx context) { }

        [CommandHipc(0)]
        public ResultCode CreateMonitorService(ServiceCtx ctx)
        {
            MakeObject(ctx,new IMonitorService(ctx));
            return ResultCode.Success;
        }
    }
}