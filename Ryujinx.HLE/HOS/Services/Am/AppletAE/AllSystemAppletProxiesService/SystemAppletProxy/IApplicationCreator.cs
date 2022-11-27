namespace Ryujinx.HLE.HOS.Services.Am.AppletAE.AllSystemAppletProxiesService.SystemAppletProxy
{
    class IApplicationCreator : IpcService
    {
        public IApplicationCreator() { }

        [CommandHipc(10)]
        public ResultCode CreateSystemApplication(ServiceCtx ctx)
        {
            MakeObject(ctx, new IApplicationAccessor(ctx));
            return ResultCode.Success;
        }

        [CommandHipc(100)]
        public ResultCode PopFloatingApplicationForDevelopment(ServiceCtx ctx)
        {
            MakeObject(ctx, new IApplicationAccessor(ctx));
            return ResultCode.Success;
        }
    }
}