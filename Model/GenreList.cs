using Noamedia__Show_Media_By_Noam_Levi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GenreList : List<Genre>
    {
        public GenreList() { }
        public GenreList(IEnumerable<Genre> list) : base(list) { }
        public GenreList(IEnumerable<BaseEntity> list) : base(list.Cast<Genre>().ToList()) { }
    }
}