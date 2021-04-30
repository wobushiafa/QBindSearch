using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q绑信息查询.Model
{
    public class NumSearch
    {
        /// <summary>
        /// 回执代码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 回执消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据QQ号或手机号
        /// </summary>
        public Data Data { get; set; }

        public string Tips { get; set; }
    }
}
