using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Int64 = LibHac.Fs.Int64;

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

        [CommandHipc(47)]
        public ResultCode GetTotalSpaceSize(ServiceCtx context)
        {
            context.ResponseData.Write((long)32000000000);
            return ResultCode.Success;
        }
        [CommandHipc(48)]

        public ResultCode GetFreeSpaceSize(ServiceCtx context)
        {
            context.ResponseData.Write((long)28000000000);
            return ResultCode.Success;
        }
    }
}