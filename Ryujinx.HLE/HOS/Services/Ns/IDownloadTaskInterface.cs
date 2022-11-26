using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Ipc;
using Ryujinx.HLE.HOS.Kernel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Ns
{
    internal class IDownloadTaskInterface : IpcService
    {
        public IDownloadTaskInterface(ServiceCtx context) { }

        [CommandHipc(701)]
        public ResultCode ClearTaskStatusList(ServiceCtx context)
        {
            return ResultCode.Success;
        }

        [CommandHipc(702)]
        public ResultCode RequestDownloadTasakList(ServiceCtx context)
        {
            return ResultCode.Success;
        }

        private int _evHandle;

        [CommandHipc(703)]
        public ResultCode RequestEnsureDownloadTask(ServiceCtx ctx)
        {
            if (_evHandle == 0)
            {
                if (ctx.Process.HandleTable.GenerateHandle(ctx.Device.System.DownloadTaskEvent.ReadableEvent, out _evHandle) != KernelResult.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }

            ctx.Response.HandleDesc = IpcHandleDesc.MakeCopy(_evHandle);

            Logger.Stub?.PrintStub(LogClass.ServiceAm);

            return ResultCode.Success;
        }


        [CommandHipc(706)]
        public ResultCode TryCommitCurrentApplicationDownloadTask(ServiceCtx context)
        {
            return ResultCode.Success;
        }
        [CommandHipc(707)]
        public ResultCode EnableAutoCommit(ServiceCtx context)
        {
            return ResultCode.Success;
        }
        [CommandHipc(708)]
        public ResultCode DisableAudoCommit(ServiceCtx context)
        {
            return ResultCode.Success;
        }
        [CommandHipc(709)]
        public ResultCode TrigggerDynamicCommitEvent(ServiceCtx context)
        {
            return ResultCode.Success;
        }
    }
}
