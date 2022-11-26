namespace Ryujinx.HLE.HOS.Services.Ovln
{
    [Service("ovln:snd")]
    class ISenderService : IpcService
    {
        public ISenderService(ServiceCtx context) { }

        [CommandHipc(0)]
        public ResultCode OpenSender(ServiceCtx ctx)
        {
            MakeObject(ctx,new ISender(ctx));
            return ResultCode.Success;
        }

    }
}