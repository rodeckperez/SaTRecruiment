using Sat.Recruiment.Common.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Sat.Recruiment.Common.Utils
{
    [ExcludeFromCodeCoverage]
    public class Message
    {
        public Message(string text, MessageType type)
        {
            this.Text = text;
            this.Type = type;
        }

        public Message(string text, string code, MessageType type)
        {
            this.Text = text;
            this.Code = code;
            this.Type = type;
        }

        public string Text { get; set; }

        public string Code { get; set; }

        public MessageType Type { get; set; }
    }
}
