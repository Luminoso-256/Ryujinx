namespace Ryujinx.HLE.HOS.Services.BluetoothManager
{
    [Service("btm:sys")]
    class IBtmSystem : IpcService
    {
        public IBtmSystem(ServiceCtx context) { }

        [CommandHipc(0)]
        public ResultCode GetCore(ServiceCtx ctx)
        {
            MakeObject(ctx, new IBtmSystemCore(ctx));
            return ResultCode.Success;
        }
    }
}