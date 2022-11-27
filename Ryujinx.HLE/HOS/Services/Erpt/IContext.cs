using Ryujinx.Common.Logging;

namespace Ryujinx.HLE.HOS.Services.Erpt
{
    [Service("erpt:c")]
    class IContext : IpcService
    {
        public IContext(ServiceCtx context) { }

        [CommandHipc(0)]
        public ResultCode SubmitContext(ServiceCtx context)
        {
            Logger.Warning?.Print(LogClass.Application,"Error Report Context was submitted.");
            return ResultCode.Success;
        }

        [CommandHipc(2)]
        public ResultCode SetInitialLaunchSettingsCompletionTime(ServiceCtx context)
        {
            return ResultCode.Success;
        }
        [CommandHipc(3)]
        public ResultCode ClearInitialLaunchSettingsCompletionTime(ServiceCtx context)
        {
            return ResultCode.Success;
        }
    }
}