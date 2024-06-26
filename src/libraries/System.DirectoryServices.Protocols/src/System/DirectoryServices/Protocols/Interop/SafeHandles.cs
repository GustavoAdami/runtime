// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace System.DirectoryServices.Protocols
{
    internal sealed class HGlobalMemHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal const IntPtr _dummyPointer = 1;

        internal HGlobalMemHandle(IntPtr value) : base(true)
        {
            SetHandle(value);
        }

        protected override bool ReleaseHandle()
        {
            if (handle != _dummyPointer)
            {
                Marshal.FreeHGlobal(handle);
            }
            return true;
        }
    }
}
