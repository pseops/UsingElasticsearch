using System;

namespace Common.Views.Loggs.Response
{
    public class ResponseGetLoggsView
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Request { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string UserId { get; set; }
    }
}
