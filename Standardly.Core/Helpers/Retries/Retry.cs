// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace Standardly.Core.Helpers.Retries
{
    public static class Retry
    {
        public delegate bool ReturningBooleanFunction();
        public delegate void ReturningNothingFunction();
        public delegate string ReturningStringFunction();
        public delegate string[] ReturningStringsFunction();

        public static bool RetryOnException(int times, TimeSpan delay, ReturningBooleanFunction returningBooleanFunction)
        {
            var attempts = 0;
            do
            {
                try
                {
                    attempts++;
                    return returningBooleanFunction();
                }
                catch (Exception ex)
                {
                    if (attempts == times)
                    {
                        throw ex;
                    }

                    Task.Delay(delay).Wait();
                }
            } while (true);
        }

        public static void RetryOnException(int times, TimeSpan delay, ReturningNothingFunction returningNothingFunction)
        {
            var attempts = 0;
            do
            {
                try
                {
                    attempts++;
                    returningNothingFunction();
                    break; // Sucess! Lets exit the loop!
                }
                catch (Exception ex)
                {
                    if (attempts == times)
                    {
                        throw ex;
                    }

                    Task.Delay(delay).Wait();
                }
            } while (true);
        }

        public static string RetryOnException(int times, TimeSpan delay, ReturningStringFunction returningStringFunction)
        {
            var attempts = 0;
            do
            {
                try
                {
                    attempts++;
                    return returningStringFunction();
                }
                catch (Exception ex)
                {
                    if (attempts == times)
                    {
                        throw ex;
                    }

                    Task.Delay(delay).Wait();
                }
            } while (true);
        }

        public static string[] RetryOnException(int times, TimeSpan delay, ReturningStringsFunction returningStringsFunction)
        {
            var attempts = 0;
            do
            {
                try
                {
                    attempts++;
                    return returningStringsFunction();
                }
                catch (Exception ex)
                {
                    if (attempts == times)
                    {
                        throw ex;
                    }

                    Task.Delay(delay).Wait();
                }
            } while (true);
        }
    }
}
