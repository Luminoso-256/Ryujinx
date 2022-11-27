using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Account.Acc
{
    internal class IAdministrator : IpcService
    {
        public IAdministrator(ServiceCtx ctx) { }

        [CommandHipc(0)]
        public ResultCode CheckAvailability(ServiceCtx ctx)
        {
            return ResultCode.Success;
        }

        [CommandHipc(250)]
        public ResultCode IsLinkedWithNintendoAccount(ServiceCtx ctx)
        {
            //no thanks on that complexity
            ctx.ResponseData.Write(false);
            return ResultCode.Success;
        }
    }
}
