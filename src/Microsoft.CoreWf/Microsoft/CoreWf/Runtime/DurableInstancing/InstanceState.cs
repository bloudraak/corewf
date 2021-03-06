﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.CoreWf.Runtime.DurableInstancing
{
    public enum InstanceState
    {
        Unknown = 0,
        Uninitialized,
        Initialized,
        Completed,
    }
}
