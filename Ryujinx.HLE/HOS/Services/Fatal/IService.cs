namespace Ryujinx.HLE.HOS.Services.Fatal
{
    [Service("fatal:u")]
    class IService : IpcService
    {
        public IService(ServiceCtx context) { }

        [CommandHipc(2)]
        public ResultCode ThrowFatalWithCPUContext(ServiceCtx context)
        {
            //Well well well, we've made *quite* the mess now, haven't we?
            //eh, let it burn anyways.
            return ResultCode.Success;
        }
    }
}