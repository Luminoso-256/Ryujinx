namespace Ryujinx.HLE.HOS.Services.Notification
{
    [Service("notif:s")] // 9.0.0+
    class INotificationServicesForSystem : IpcService
    {
        public INotificationServicesForSystem(ServiceCtx context) { }

        [CommandHipc(520)]
        public ResultCode ListAlarmSettings(ServiceCtx ctx) 
        {
            ctx.ResponseData.Write(0);
            return ResultCode.Success;
        }

        [CommandHipc(1040)]
        public ResultCode GetINotificationSystemEventAccessor(ServiceCtx ctx)
        {
            MakeObject(ctx,new INotificationSystemEventAccessor(ctx));
            return ResultCode.Success;
        }

        [CommandHipc(1510)]
        public ResultCode GetPresentationSetting(ServiceCtx ctx) //THIS IS DOCUMENTED NOWHERE!!!
        {
            ctx.ResponseData.Write(0);
            return ResultCode.Success;
        }
    }
}