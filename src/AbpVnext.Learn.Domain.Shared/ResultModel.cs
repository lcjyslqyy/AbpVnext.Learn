using System;
using System.Collections.Generic;
using System.Text;

namespace AbpVnext.Learn
{
    public class ResultModel
    {
        public ResultModel(int _code,string _msg,object _data)
        {
            code = _code;
            msg = _msg;
            data = _data;
        }
        public int code  { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
    }
}
