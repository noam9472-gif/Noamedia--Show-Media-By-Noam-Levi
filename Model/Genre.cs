using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Genre : BaseEntity
    {
        private string genreDescription;

        
        public string GenreDescription { get => genreDescription; set => genreDescription = value; }
    }
}
