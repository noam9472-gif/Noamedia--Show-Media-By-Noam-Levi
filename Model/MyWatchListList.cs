using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyWatchListList : List<MyWatchList>
    {
        public MyWatchListList() { }
        public MyWatchListList(IEnumerable<MyWatchList> list) : base(list) { }
        public MyWatchListList(IEnumerable<BaseEntity> list) : base(list.Cast<MyWatchList>().ToList()) { }
    }
}
