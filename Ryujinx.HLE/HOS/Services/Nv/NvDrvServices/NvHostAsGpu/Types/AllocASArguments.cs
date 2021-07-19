using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostAsGpu.Types
{
    //from https://switchbrew.org/wiki/NV_services#NVGPU_AS_IOCTL_ALLOC_AS
    [StructLayout(LayoutKind.Sequential)]
    struct AllocASArguments
    {
        UInt32 big_page_size;
        int as_fd; //ignored
        ulong reserved; //ignored
    }
}
