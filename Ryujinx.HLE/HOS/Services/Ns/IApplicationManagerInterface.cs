using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Ipc;
using Ryujinx.HLE.HOS.Kernel.Common;
using System;

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

        private int _evHandleAppRecord;
        private int _evHandleGameCard;
     

        private int _evHandleGenericPh;

        [CommandHipc(44)]
        public ResultCode GetSdMountStatusChanged(ServiceCtx ctx)
        {
            if (_evHandleGenericPh == 0)
            {
                if (ctx.Process.HandleTable.GenerateHandle(ctx.Device.System.GenericPlaceholderEvent.ReadableEvent, out _evHandleGenericPh) != KernelResult.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }

            ctx.Response.HandleDesc = IpcHandleDesc.MakeCopy(_evHandleGenericPh);

            Logger.Stub?.PrintStub(LogClass.ServiceAm);

            return ResultCode.Success;
        }

        [CommandHipc(505)]
        public ResultCode GetGameCardMountFailureEvent(ServiceCtx ctx)
        {
            if (_evHandleGenericPh == 0)
            {
                if (ctx.Process.HandleTable.GenerateHandle(ctx.Device.System.GenericPlaceholderEvent.ReadableEvent, out _evHandleGenericPh) != KernelResult.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }

            ctx.Response.HandleDesc = IpcHandleDesc.MakeCopy(_evHandleGenericPh);

            Logger.Stub?.PrintStub(LogClass.ServiceAm);

            return ResultCode.Success;
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

        [CommandHipc(1)]
        public ResultCode GenerateApplicationRecordCount(ServiceCtx context)
        {
            context.ResponseData.Write(0); //TODO: if you want apps on qlaunch, fix this.
            return ResultCode.Success;
        }
        [CommandHipc(2)]
        public ResultCode GenerateApplicationRecordUpdateSystemEvent(ServiceCtx ctx)
        {
            if (_evHandleAppRecord == 0)
            {
                if (ctx.Process.HandleTable.GenerateHandle(ctx.Device.System.AppRecordUpdateEvent.ReadableEvent, out _evHandleAppRecord) != KernelResult.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }

            ctx.Response.HandleDesc = IpcHandleDesc.MakeCopy(_evHandleAppRecord);

            Logger.Stub?.PrintStub(LogClass.ServiceAm);

            return ResultCode.Success;
        }
        [CommandHipc(52)]
        public ResultCode GetGameCardUpdateDetectionEvent(ServiceCtx ctx)
        {
            if (_evHandleGameCard == 0)
            {
                if (ctx.Process.HandleTable.GenerateHandle(ctx.Device.System.GamecardUpdateEvent.ReadableEvent, out _evHandleGameCard) != KernelResult.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }

            ctx.Response.HandleDesc = IpcHandleDesc.MakeCopy(_evHandleGameCard);

            Logger.Stub?.PrintStub(LogClass.ServiceAm);

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