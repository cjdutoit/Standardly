// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;

namespace Standardly.Core.Models.RetryConfig
{
    public class RetryConfig : IRetryConfig
    {
        public RetryConfig()
        {
            this.MaxRetryAttempts = 3;
            this.PauseBetweenFailures = TimeSpan.FromSeconds(2);
        }

        public RetryConfig(int maxRetryAttempts, TimeSpan pauseBetweenFailures)
        {
            this.MaxRetryAttempts = maxRetryAttempts;
            this.PauseBetweenFailures = pauseBetweenFailures;
        }

        public int MaxRetryAttempts { get; private set; }
        public TimeSpan PauseBetweenFailures { get; private set; }
    }
}
