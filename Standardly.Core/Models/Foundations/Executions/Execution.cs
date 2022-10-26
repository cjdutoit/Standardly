// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace Standardly.Core.Models.Foundations.Executions
{
    public class Execution
    {
        public Execution()
        { }

        public Execution(string name, string instruction)
        {
            Name = name;
            Instruction = instruction;
        }

        public string Name { get; set; }
        public string Instruction { get; set; }
    }
}
