using System;
using System.Collections.Generic;
using System.Text;

namespace AbpVnext.Learn
{
    public class ResultModel<T>
    {
        public ResultModel(int _code,string _msg,T _data)
        {
            code = _code;
            msg = _msg;
            data = _data;
        }
        /// <summary>
        /// 0为成功，其它为失败
        /// </summary>
        public int code  { get; set; }
        public string msg { get; set; }
        public T data { get; set; }
    }
}
