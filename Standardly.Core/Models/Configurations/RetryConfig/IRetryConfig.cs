// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;

namespace Standardly.Core.Models.Configurations.RetryConfig
{
    public interface IRetryConfig
    {
        int MaxRetryAttempts { get; }
        TimeSpan PauseBetweenFailures { get; }
    }
}
