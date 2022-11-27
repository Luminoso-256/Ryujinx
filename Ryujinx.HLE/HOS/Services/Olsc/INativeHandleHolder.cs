using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Ipc;
using Ryujinx.HLE.HOS.Kernel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Olsc
{
    class INativeHandleHolder : IpcService
    {
        public INativeHandleHolder(ServiceCtx context) { }

        private int _genericEventHandle;

        [CommandHipc(0)]
        public ResultCode GetNativeHandle(ServiceCtx context) 
        {
            if (_genericEventHandle == 0)
            {
                if (context.Process.HandleTable.GenerateHandle(context.Device.System.GenericPlaceholderEvent.ReadableEvent, out _genericEventHandle) != KernelResult.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }

            context.Response.HandleDesc = IpcHandleDesc.MakeCopy(_genericEventHandle);
            return ResultCode.Success;
        }
    }
}
