namespace Ryujinx.HLE.HOS.Services.Am.AppletAE.AllSystemAppletProxiesService.SystemAppletProxy
{
    class IApplicationCreator : IpcService
    {
        public IApplicationCreator() { }

        [CommandHipc(100)]
        public ResultCode PopFloatingApplicationForDevelopment(ServiceCtx ctx)
        {
            MakeObject(ctx, new IApplicationAccessor(ctx));
            return ResultCode.Success;
        }
    }
}