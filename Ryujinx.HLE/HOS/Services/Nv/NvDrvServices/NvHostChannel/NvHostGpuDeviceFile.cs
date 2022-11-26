using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Kernel.Common;
using Ryujinx.HLE.HOS.Kernel.Threading;
using Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostChannel.Types;
using Ryujinx.Memory;
using System;

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostChannel
{
    internal class NvHostGpuDeviceFile : NvHostChannelDeviceFile
    {
        private KEvent _smExceptionBptIntReportEvent;
        private KEvent _smExceptionBptPauseReportEvent;
        private KEvent _errorNotifierEvent;

        private int _smExceptionBptIntReportEventHandle;
        private int _smExceptionBptPauseReportEventHandle;
        private int _errorNotifierEventHandle;

        public NvHostGpuDeviceFile(ServiceCtx context, IVirtualMemoryManager memory, ulong owner) : base(context, memory, owner)
        {
            _smExceptionBptIntReportEvent   = CreateEvent(context, out _smExceptionBptIntReportEventHandle);
            _smExceptionBptPauseReportEvent = CreateEvent(context, out _smExceptionBptPauseReportEventHandle);
            _errorNotifierEvent             = CreateEvent(context, out _errorNotifierEventHandle);
        }

        private static KEvent CreateEvent(ServiceCtx context, out int handle)
        {
            KEvent evnt = new KEvent(context.Device.System.KernelContext);

            if (context.Process.HandleTable.GenerateHandle(evnt.ReadableEvent, out handle) != KernelResult.Success)
            {
                throw new InvalidOperationException("Out of handles!");
            }

            return evnt;
        }

        public override NvInternalResult Ioctl(NvIoctl command, Span<byte> arguments)
        {
            NvInternalResult result = NvInternalResult.NotImplemented;

            switch (command.Number)
            {
                case 0x01:
                    Logger.Info?.Print(LogClass.ServiceNv, "stubbed 0x01 Ioctl (why does this exist what does it do?)");
                    result = NvInternalResult.Success;
                    break;
                case 0x05:
                    Logger.Info?.Print(LogClass.ServiceNv, "stubbed 0x05 MapSharedMem");
                    result = NvInternalResult.Success;
                    break;
                case 0x07:
                    Logger.Info?.Print(LogClass.ServiceNv,"stubbed 0x07 SetAruidWithoutCheck");
                    result =  NvInternalResult.Success;
                    break;
                case 0x09:
                    Logger.Info?.Print(LogClass.ServiceNv, "stubbed 0x09 DumpFile");
                    result = NvInternalResult.Success;
                    break;
                case 12:
                    Logger.Info?.Print(LogClass.ServiceNv, "stubbed 12 Ioctl3 (this is definitely a bad idea)");
                    result = NvInternalResult.Success;
                    break;
                default:
                    Logger.Error?.Print(LogClass.ServiceNv,$"Uh oh! We missed a NvHostGPUDeviceFile case :({command.Number}. We're gonna stub it anyways and watch the world burn.");
                    result = NvInternalResult.Success;
                    break;
            }

            return result;
        }

        public override NvInternalResult Ioctl2(NvIoctl command, Span<byte> arguments, Span<byte> inlineInBuffer)
        {
            NvInternalResult result = NvInternalResult.NotImplemented;

            if (command.Type == NvIoctl.NvHostMagic)
            {
                switch (command.Number)
                {
                    case 0x1b:
                        result = CallIoctlMethod<SubmitGpfifoArguments, ulong>(SubmitGpfifoEx, arguments, inlineInBuffer);
                        break;
                }
            }

            return result;
        }

        public override NvInternalResult QueryEvent(out int eventHandle, uint eventId)
        {
            // TODO: accurately represent and implement those events.
            switch (eventId)
            {
                case 0x1:
                    eventHandle = _smExceptionBptIntReportEventHandle;
                    break;
                case 0x2:
                    eventHandle = _smExceptionBptPauseReportEventHandle;
                    break;
                case 0x3:
                    eventHandle = _errorNotifierEventHandle;
                    break;
                default:
                    eventHandle = 0;
                    break;
            }

            return eventHandle != 0 ? NvInternalResult.Success : NvInternalResult.InvalidInput;
        }

        private NvInternalResult SubmitGpfifoEx(ref SubmitGpfifoArguments arguments, Span<ulong> inlineData)
        {
            return SubmitGpfifo(ref arguments, inlineData);
        }

        public override void Close()
        {
            if (_smExceptionBptIntReportEventHandle != 0)
            {
                Context.Process.HandleTable.CloseHandle(_smExceptionBptIntReportEventHandle);
                _smExceptionBptIntReportEventHandle = 0;
            }

            if (_smExceptionBptPauseReportEventHandle != 0)
            {
                Context.Process.HandleTable.CloseHandle(_smExceptionBptPauseReportEventHandle);
                _smExceptionBptPauseReportEventHandle = 0;
            }

            if (_errorNotifierEventHandle != 0)
            {
                Context.Process.HandleTable.CloseHandle(_errorNotifierEventHandle);
                _errorNotifierEventHandle = 0;
            }

            base.Close();
        }
    }
}
