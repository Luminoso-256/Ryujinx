namespace Ryujinx.HLE.HOS.Services.Settings
{
    [Service("set:fd")]
    class IFirmwareDebugSettingsServer : IpcService
    {
        public IFirmwareDebugSettingsServer(ServiceCtx context) { }

        [CommandHipc(3)]
        public ResultCode ResetSettingsItemValue(ServiceCtx ctx)
        {
            //well, there's nothing to reset so why not
            return ResultCode.Success;
        }
    }
}