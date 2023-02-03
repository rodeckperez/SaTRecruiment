using Sat.Recruiment.Common.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Sat.Recruiment.Common.Utils
{
    [ExcludeFromCodeCoverage]
    public class Response<T> : Response
    {
        public Response()
        {

        }

        public Response(T data) {
            this.Data = data;
        }

        public T Data { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class Response
    {
        public Response()
        {
            this.Messages = new List<Message>();
        }

        public IList<Message> Messages { get; set; }

        public bool HasErrors
        {
            get { return this.Messages.Any(x => x.Type.Equals(MessageType.Error)); }
        }

        public bool HasInternalServerError
        {
            get { return this.Messages.Any(x => x.Type.Equals(MessageType.Error) && x.Code == "500"); }
        }

        public void AddMessages(IList<Message> list)
        {
            foreach (var message in list)
            {
                this.Messages.Add(message);
            }
        }

        public void AddError(string message) => this.Messages.Add(new Message(message, MessageType.Error));

        public void AddSuccess(string message) => this.Messages.Add(new Message(message,  MessageType.Success));
    }
}
