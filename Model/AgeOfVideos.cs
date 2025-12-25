using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class AgeOfVideos : BaseEntity
    {
        private string description;

      
        public string Description { get => description; set => description = value; }
    }
}
