using System.Collections.Generic;

namespace Standardly.Core.Models.Tasks
{
    public class Task
    {
        public string Name { get; set; }
        public List<Models.Actions.Action> Actions { get; set; } = new List<Models.Actions.Action>();
    }
}
