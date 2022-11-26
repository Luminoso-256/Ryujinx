namespace Ryujinx.HLE.HOS.Services.Audio
{
    [Service("audctl")]
    class IAudioController : IpcService
    {
        public IAudioController(ServiceCtx context) { }

        [CommandHipc(12)]
        public ResultCode getForceMutePolicy(ServiceCtx ctx)
        {
            ctx.ResponseData.Write(true);//my best guess
            return ResultCode.Success;
        }

        [CommandHipc(13)]
        public ResultCode GetOutputMode(ServiceCtx ctx) //THIS IS DOCUMENTED NOWHERE!!!
        {
            ctx.ResponseData.Write(0);
            return ResultCode.Success;
        }

        [CommandHipc(18)]
        public ResultCode GetHeadphoneOutputLevelMode(ServiceCtx ctx)//THIS IS DOCUMENTED NOWHERE!!!
        {
            ctx.ResponseData.Write(0);
            return ResultCode.Success;
        }
    }
}