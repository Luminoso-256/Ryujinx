namespace Ryujinx.HLE.HOS.Services.Ns
{
    [Service("ns:am")]
    class IApplicationManagerInterface : IpcService
    {
        public IApplicationManagerInterface(ServiceCtx context) { }

        public struct ApplicationRecord
        {
            ulong ApplicationID;
            byte Type;
            byte Unknown1;
            byte unknown2_1;
            byte unknown2_2;
            byte unknown2_3;
            byte unknown2_4;
            byte unknown2_5;
            byte unknown2_6;
            byte Unknown3;
            byte unknown4_1;
            byte unknown4_2;
            byte unknown4_3;
            byte unknown4_4;
            byte unknown4_5;
            byte unknown4_6;
            byte unknown4_7;
        }


        [CommandHipc(0)]
        public ResultCode ListApplicationRecord(ServiceCtx context)
        {
            //TODO if we want to make this *actually* work: read the input and do stuff:tm:
            //for now, just return  and be done with it
            context.ResponseData.Write(0);

            //no matter what, we will claim success for the sake of getting this through.
            return ResultCode.Success;
        }

        [CommandHipc(400)]
        // GetApplicationControlData(u8, u64) -> (unknown<4>, buffer<unknown, 6>)
        public ResultCode GetApplicationControlData(ServiceCtx context)
        {
            byte  source  = (byte)context.RequestData.ReadInt64();
            ulong titleId = context.RequestData.ReadUInt64();

            ulong position = context.Request.ReceiveBuff[0].Position;

            byte[] nacpData = context.Device.Application.ControlData.ByteSpan.ToArray();

            context.Memory.Write(position, nacpData);

            return ResultCode.Success;
        }
    }
}