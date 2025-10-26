using Noamedia__Show_Media_By_Noam_Levi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Genre : Base_entity
    {
        private string identityCard;
        private string genreDescription;

        public string IdentityCard { get => identityCard; set => identityCard = value; }
        public string GenreDescription { get => genreDescription; set => genreDescription = value; }
    }
}
