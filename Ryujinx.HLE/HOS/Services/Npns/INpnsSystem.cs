namespace Ryujinx.HLE.HOS.Services.Npns
{
    [Service("npns:s")]
    class INpnsSystem : IpcService
    {
        public INpnsSystem(ServiceCtx context) { }

        [CommandHipc(101)]
        //https://reswitched.github.io/SwIPC/ifaces.html#nn::npns::INpnsSystem(101)
        public ResultCode Unknown101(ServiceCtx context)
        {
            return ResultCode.Success;
        }
    }
}