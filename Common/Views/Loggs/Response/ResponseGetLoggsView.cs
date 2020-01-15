using System;
using System.Collections.Generic;

namespace Common.Views.Loggs.Response
{
    public class ResponseGetLoggsView
    {
        public List<ResponseGetLoggsViewItem> Items { get; set; }
        public int Count { get; set; }
    }
    public class ResponseGetLoggsViewItem
    {
        public long Id { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreationDate { get; set; }
        public string Request { get; set; }
        
        public string Source { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string UserId { get; set; }
    }
}
