using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;
using System;
using System.Linq;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")] // נתיב בסיסי: api/Insert
    [ApiController]
    public class InsertController : Controller
    {
        [HttpPost("VideoInserter")]
        public int AddVideo([FromBody] Video v)
        {
            try
            {
                VideoDB vdb = new();
                vdb.Insert(v);
                return vdb.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("INSERT ERROR: " + ex.Message);
                return 0;
            }
        }

        [HttpPost("UserInserter")]
        public int InsertUser([FromBody] User user)
        {
            UserDB udb = new UserDB();
            udb.Insert(user);
            return udb.SaveChanges();
        }

        [HttpPost("InserterGenre")]
        public int InsertGenre([FromBody] Genre genre)
        {
            GenreDB gdb = new GenreDB();
            gdb.Insert(genre);
            return gdb.SaveChanges();
        }

        [HttpPost("VideoReviewInserter")]
        public int InsertVideoReview([FromBody] VideoReview videoReview)
        {
            VideoReviewDB vrdb = new VideoReviewDB();
            vrdb.Insert(videoReview);
            return vrdb.SaveChanges();
        }

        [HttpPost("UserPremiumInserter")]
        public int UserPremiumInserter([FromBody] UserPremium up)
        {
            try
            {
                UserPremiumDB updb = new UserPremiumDB();
                updb.Insert(up);
                return updb.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0;
            }
        }

        [HttpPost("MyLikesInserter")]
        public int InsertMyLike([FromBody] MyLikes like)
        {
            MyLikesDB mldb = new MyLikesDB();
            mldb.Insert(like);
            return mldb.SaveChanges();
        }

        [HttpPost("MyWatchListInserter")]
        public int InsertMyWatchList([FromBody] MyWatchList item)
        {
            MyWatchListDB mwldb = new MyWatchListDB();
            mwldb.Insert(item);
            return mwldb.SaveChanges();
        }

        [HttpPost("MyHistoryInserter")]
        public int InsertMyHistory([FromBody] MyHistory item)
        {
            MyHistoryDB mhdb = new MyHistoryDB();
            mhdb.Insert(item);
            return mhdb.SaveChanges();
        }
    }
}