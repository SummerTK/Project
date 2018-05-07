using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class View_UserModel
    {
        public string 表名 { get; set; }
        public Nullable<short> 字段序号 { get; set; }
        public string 字段名 { get; set; }
        public string 标识 { get; set; }
        public string 主键 { get; set; }
        public string 类型 { get; set; }
        public short 占用字节数 { get; set; }
        public Nullable<int> 长度 { get; set; }
        public int 小数位数 { get; set; }
        public string 允许空 { get; set; }
        public string 默认值 { get; set; }
    }
}
