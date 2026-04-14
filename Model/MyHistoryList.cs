using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyHistoryList : List<MyHistory>
    {
        public MyHistoryList() { }
        public MyHistoryList(IEnumerable<MyHistory> list) : base(list) { }
        public MyHistoryList(IEnumerable<BaseEntity> list) : base(list.Cast<MyHistory>().ToList()) { }
    }
}
