using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Model
{
    public class MessageModel<T>
    {
        public bool success { get; set; } = false;

        public string msg { get; set; } = "服务器异常";

        public T response { get; set; }
    }
}
