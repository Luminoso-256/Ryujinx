using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Ns
{
    class IContentManagementInterface : IpcService
    {
        public IContentManagementInterface(ServiceCtx context) { }

        [CommandHipc(43)]
        public ResultCode CheckSdCardMountStatus(ServiceCtx context)
        {
            //returns nothing, so does nothing.
            return ResultCode.Success;
        }
    }
}
