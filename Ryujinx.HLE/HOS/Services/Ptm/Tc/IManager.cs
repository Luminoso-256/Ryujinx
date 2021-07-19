namespace Ryujinx.HLE.HOS.Services.Ptm.Tc
{
    [Service("tc")]
    class IManager : IpcService
    {
        public IManager(ServiceCtx context) { }

        [CommandHipc(8)]
        public ResultCode Unknown8(ServiceCtx context)
        {
            context.ResponseData.Write(false); //it says it returns an unknown<1>, so lets start with 1 byte.
            return ResultCode.Success;
        }
    }
}