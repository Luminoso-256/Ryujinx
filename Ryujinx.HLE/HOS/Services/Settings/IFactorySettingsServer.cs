namespace Ryujinx.HLE.HOS.Services.Am.Tcap
{
    [Service("set:cal")]
    class IFactorySettingsServer : IpcService
    {
        public IFactorySettingsServer(ServiceCtx context) { }

        [CommandHipc(1)]
        public ResultCode GetConfigurationId1(ServiceCtx context)
        {
            context.ResponseData.Write(new byte[29]);
            return ResultCode.Success;
        }
    }
}