namespace Ryujinx.HLE.HOS.Services.Ptm.Fan
{
    [Service("fan")]
    class IManager : IpcService
    {
        public IManager(ServiceCtx context) { }

        [CommandHipc(0)]
        public ResultCode unknown0(ServiceCtx context)
        {
            MakeObject(context, new Services.Ptm.Fan.IController());
            //  context.ResponseData.Write(new Services.Ptm.Fan.IController());
            return ResultCode.Success;
        }
    }
}