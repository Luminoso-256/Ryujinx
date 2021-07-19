using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Am.AppletAE
{
    class IApplicationProxy : IpcService
    {
        private readonly long _pid;

        public IApplicationProxy(long pid)
        {
            _pid = pid;
        }

        [CommandHipc(0)]
        public ResultCode GetCommonStateGetter(ServiceCtx context)
        {
            MakeObject(context, new AppletAE.AllSystemAppletProxiesService.SystemAppletProxy.ICommonStateGetter(context));
            return ResultCode.Success;
        }
        [CommandHipc(1)]
        public ResultCode GetSelfController(ServiceCtx context)
        {
            MakeObject(context, new AppletAE.AllSystemAppletProxiesService.SystemAppletProxy.ICommonStateGetter(context));
            return ResultCode.Success;
        }
        [CommandHipc(2)]
        public ResultCode GetWindowController(ServiceCtx context)
        {
            MakeObject(context, new AppletAE.AllSystemAppletProxiesService.SystemAppletProxy.IWindowController(_pid));
            return ResultCode.Success;
        }
        [CommandHipc(3)]
        public ResultCode GetAudioController(ServiceCtx context)
        {
            MakeObject(context, new AppletAE.AllSystemAppletProxiesService.SystemAppletProxy.IAudioController());
            return ResultCode.Success;
        }
        [CommandHipc(4)]
        public ResultCode GetDisplayController(ServiceCtx context)
        {
            MakeObject(context, new AppletAE.AllSystemAppletProxiesService.SystemAppletProxy.IDisplayController(context));
            return ResultCode.Success;
        }
    
        [CommandHipc(1000)]
        public ResultCode GetDebugFunctions(ServiceCtx context)
        {
            MakeObject(context, new AppletAE.AllSystemAppletProxiesService.SystemAppletProxy.IDebugFunctions());
            return ResultCode.Success; 
        }

        [CommandHipc(20)]
        public ResultCode GetApplicationFunctions(ServiceCtx context)
        {
            MakeObject(context, new AppletOE.ApplicationProxyService.ApplicationProxy.IApplicationFunctions(context.Device.System));
            return ResultCode.Success;
        }
        
        [CommandHipc(11)]
        public ResultCode GetLibraryAppletCreator(ServiceCtx context)
        {
            MakeObject(context, new AllSystemAppletProxiesService.SystemAppletProxy.ILibraryAppletCreator());
            return ResultCode.Success;
        }
    }
}
