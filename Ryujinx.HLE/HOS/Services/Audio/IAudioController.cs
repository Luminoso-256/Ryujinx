namespace Ryujinx.HLE.HOS.Services.Audio
{
    [Service("audctl")]
    class IAudioController : IpcService
    {
        public IAudioController(ServiceCtx context) { }

        [CommandHipc(12)]
        public ResultCode GetForceMutePolicy(ServiceCtx ctx)
        {
            //https://github.com/switchbrew/libnx/blob/4a850437f2b399f41bd23536b5300062ed8011e4/nx/include/switch/services/audctl.h#L30
            ctx.ResponseData.Write(0);
            return ResultCode.Success;
        }

        [CommandHipc(13)]
        public ResultCode GetOutputMode(ServiceCtx ctx) 
        {
            //https://github.com/switchbrew/libnx/blob/4a850437f2b399f41bd23536b5300062ed8011e4/nx/include/switch/services/audctl.h#L22
            ctx.ResponseData.Write(4);
            return ResultCode.Success;
        }

        [CommandHipc(18)]
        public ResultCode GetHeadphoneOutputLevelMode(ServiceCtx ctx)//THIS IS DOCUMENTED NOWHERE!!!
        {
            //https://github.com/switchbrew/libnx/blob/4a850437f2b399f41bd23536b5300062ed8011e4/nx/include/switch/services/audctl.h#L30
            ctx.ResponseData.Write(0);
            return ResultCode.Success;
        }
    }
}