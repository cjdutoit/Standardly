// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Extensibility.UI;

namespace Standardly.ToolWindows
{
    /// <summary>
    /// ViewModel for the GenerateCodeToolWindowContent remote user control.
    /// </summary>
    [DataContract]
    internal class GenerateCodeToolWindowData : NotifyPropertyChangedObject
    {
        public GenerateCodeToolWindowData()
        {
            HelloCommand = new AsyncCommand((parameter, cancellationToken) =>
            {
                Text = $"Hello {parameter as string}!";
                return Task.CompletedTask;
            });
        }

        private string _name = string.Empty;
        [DataMember]
        public string Name
        {
            get => _name;
            set => SetProperty(ref this._name, value);
        }

        private string _text = string.Empty;
        [DataMember]
        public string Text
        {
            get => _text;
            set => SetProperty(ref this._text, value);
        }

        [DataMember]
        public AsyncCommand HelloCommand { get; }
    }
}
