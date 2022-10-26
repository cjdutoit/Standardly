// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;

namespace Standardly.Core.Models.Configurations.RetryConfig
{
    public class RetryConfig : IRetryConfig
    {
        public RetryConfig()
        {
            MaxRetryAttempts = 3;
            PauseBetweenFailures = TimeSpan.FromSeconds(2);
        }

        public RetryConfig(int maxRetryAttempts, TimeSpan pauseBetweenFailures)
        {
            MaxRetryAttempts = maxRetryAttempts;
            PauseBetweenFailures = pauseBetweenFailures;
        }

        public int MaxRetryAttempts { get; private set; }
        public TimeSpan PauseBetweenFailures { get; private set; }
    }
}
