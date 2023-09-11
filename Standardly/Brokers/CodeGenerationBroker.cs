// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Standardly.Core.Clients;

namespace Standardly.Brokers
{
    internal partial class CodeGenerationBroker : ICodeGenerationBroker
    {
        private readonly StandardlyClient standardlyClient;

        public CodeGenerationBroker()
        {
            standardlyClient = new StandardlyClient();
        }
    }
}
