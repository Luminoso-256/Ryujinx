using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Services.Am.AppletAE.AllSystemAppletProxiesService;
using Ryujinx.HLE.HOS.Services.Am.AppletOE.ApplicationProxyService;

namespace Ryujinx.HLE.HOS.Services.Am.AppletAE
{
    [Service("appletAE")]
    class IAllSystemAppletProxiesService : IpcService
    {
        public IAllSystemAppletProxiesService(ServiceCtx context) { }

        [CommandHipc(40)]
        public ResultCode shouldNotExist(ServiceCtx context)
        {
            Logger.Warning?.Print(LogClass.ServiceAm, "IAllSystemAppletProxiesService:40 was called. This *technically* shouldn't exist.");
            return ResultCode.Success;
        }

        [CommandHipc(100)]
        // OpenSystemAppletProxy(u64, pid, handle<copy>) -> object<nn::am::service::ISystemAppletProxy>
        public ResultCode OpenSystemAppletProxy(ServiceCtx context)
        {
            MakeObject(context, new ISystemAppletProxy(context.Request.HandleDesc.PId));

            return ResultCode.Success;
        }

        [CommandHipc(200)]
        [CommandHipc(201)] // 3.0.0+
        // OpenLibraryAppletProxy(u64, pid, handle<copy>) -> object<nn::am::service::ILibraryAppletProxy>
        public ResultCode OpenLibraryAppletProxy(ServiceCtx context)
        {
            MakeObject(context, new ILibraryAppletProxy(context.Request.HandleDesc.PId));

            return ResultCode.Success;
        }

        [CommandHipc(350)]
        public ResultCode OpenSystemApplicationProxy(ServiceCtx ctx)
        {
            MakeObject(ctx,new IApplicationProxy(ctx.Device.Application.TitleId));
            return ResultCode.Success;
        }
    }
}