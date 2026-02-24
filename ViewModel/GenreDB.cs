using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GenreDB : BaseDB
    {
        public GenreList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Genre";
            GenreList groupList = new GenreList(base.Select());
            return groupList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Genre ct = entity as Genre;
            ct.GenreDescription = reader["GenreDescription"].ToString();
            base.CreateModel(entity);
            return ct;
        }
        public override BaseEntity NewEntity()
        {
            return new Genre();
        }
        static private GenreList list = new GenreList();

        public static Genre SelectById(int id)
        {
            GenreDB db = new GenreDB();
            list = db.SelectAll();

            Genre g = list.Find(item => item.Id == id);
            return g;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Genre g = entity as Genre;
            if (g != null)
            {
                string sqlStr = $"DELETE FROM [User] WHERE ID=@ID";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@ID", g.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Genre g = entity as Genre;
            if (g != null)
            {
                string sqlStr = $"Insert INTO Genre (Genredescription) VALUES (@Genredescription)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@Genredescription", g.GenreDescription));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Genre g = entity as Genre;
            if (g != null)
            {
                string sqlStr = $"UPDATE Genre SET Genredescription=@Genredescription " +
                    $"WHERE ID=@ID";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@Genredescription", g.GenreDescription));
                command.Parameters.Add(new OleDbParameter("@ID", g.Id));
            }
        }
    }
}