using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q绑信息查询.Model
{
    public class Place
    {
        /// <summary>
        /// 手机号归属地-省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 手机号归属地-城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// 运营商
        /// </summary>
        public string SP { get; set; }

        /// <summary>
        /// 电话前缀
        /// </summary>
        public string Tel { get; set; }
    }
}
