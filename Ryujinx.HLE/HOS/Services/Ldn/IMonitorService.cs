using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Ldn
{
    class IMonitorService : IpcService
    {
        public IMonitorService(ServiceCtx context) { }

        [CommandHipc(0)]
        public ResultCode GetStateForMonitor(ServiceCtx ctx)
        {
            ctx.ResponseData.Write(0); //no idea. literally none.
            return ResultCode.Success;
        }

        [CommandHipc(100)]
        public ResultCode InitializeMonitor(ServiceCtx ctx)
        {
            return ResultCode.Success;
        }
        [CommandHipc(101)]
        public ResultCode FinalizeMonitor(ServiceCtx ctx)
        {
            return ResultCode.Success;
        }
    }
}