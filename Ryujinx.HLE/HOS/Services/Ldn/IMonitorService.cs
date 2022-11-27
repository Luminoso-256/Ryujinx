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
            //https://github.com/switchbrew/libnx/blob/c5a9a909a91657a9818a3b7e18c9b91ff0cbb6e3/nx/include/switch/services/ldn.h
            ctx.ResponseData.Write(1); //Initialized.
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