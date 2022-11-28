using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Ipc;
using Ryujinx.HLE.HOS.Kernel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.BluetoothManager
{
    internal class IBtmSystemCore : IpcService
    {
        public IBtmSystemCore(ServiceCtx context) { }

        [CommandHipc(0)]
        public ResultCode StartGamepadPairing(ServiceCtx ctx)
        {
            return ResultCode.Success;
        }
        [CommandHipc(1)]
        public ResultCode CancelGamepadPairing(ServiceCtx ctx)
        {
            return ResultCode.Success;
        }
        [CommandHipc(2)]
        public ResultCode ClearGamepadPairingDatabase(ServiceCtx ctx)
        {
            return ResultCode.Success;
        }

        [CommandHipc(6)]
        public ResultCode IsRadioEnabled(ServiceCtx ctx)
        {
            ctx.ResponseData.Write(true);
            return ResultCode.Success;
        }

        private int _genericEvHandle;
        [CommandHipc(7)]
        public ResultCode AquireRadioEvent(ServiceCtx ctx)
        {
            if (_genericEvHandle == 0)
            {
                if (ctx.Process.HandleTable.GenerateHandle(ctx.Device.System.GenericPlaceholderEvent.ReadableEvent, out _genericEvHandle) != KernelResult.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }
          
            ctx.Response.HandleDesc = IpcHandleDesc.MakeCopy(_genericEvHandle);
            ctx.ResponseData.Write(true);
            Logger.Stub?.PrintStub(LogClass.ServiceAm);

            return ResultCode.Success;
        }
        [CommandHipc(8)]
        public ResultCode AquireGamepadPairingEvent(ServiceCtx ctx)
        {
            if (_genericEvHandle == 0)
            {
                if (ctx.Process.HandleTable.GenerateHandle(ctx.Device.System.GenericPlaceholderEvent.ReadableEvent, out _genericEvHandle) != KernelResult.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }
          
            ctx.Response.HandleDesc = IpcHandleDesc.MakeCopy(_genericEvHandle);

            Logger.Stub?.PrintStub(LogClass.ServiceAm);

            return ResultCode.Success;
        }
        [CommandHipc(9)]
        public ResultCode IsGamepadPairingStarted(ServiceCtx ctx)
        {
           
            ctx.ResponseData.Write(false);
          
            return ResultCode.Success;
        }


    }
}
