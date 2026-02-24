using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

namespace Movies.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SelectController : Controller
    {
        [HttpGet]
        [ActionName("VideoSelector")]
        public VideoList SelectAllVideos()
        {
            VideoDB db = new VideoDB();
            VideoList videos = db.SelectAll();
            return videos;
        }
        [HttpGet]
        [ActionName("UserSelector")]
        public UserList SelectAllUsers()
        {
            UserDB db = new UserDB();
            UserList videos = db.SelectAll();
            return videos;
        }
        [HttpGet]
        [ActionName("GenreSelector")]
        public GenreList SelectAllGenres()
        {
            GenreDB db = new GenreDB();
            GenreList genres = db.SelectAll();
            return genres;
        }
        [HttpGet]
        [ActionName("VideoReviewSelector")]
        public VideoReviewList SelectAllVideoReviews()
        {
            VideoReviewDB db = new VideoReviewDB();
            VideoReviewList videoReviews = db.SelectAll();
            return videoReviews;
        }
        [HttpGet]
        [ActionName("AgeOfVideoSelector")]
        public AgeOfVideoList SelectAllAgeOfVideos()
        {
            AgeOfVideosDB db = new AgeOfVideosDB();
            AgeOfVideoList ageOfVideos = db.SelectAll();
            return ageOfVideos;
        }
        [HttpGet]
        [ActionName("UserPremiumSelector")]
        public UserPremiumList SelectAllUserPremiums()
        {
            UserPremiumDB db = new UserPremiumDB();
            UserPremiumList movies = db.SelectAll();
            return movies;
        }
        [HttpGet("VideoPicSelector64Byte/{id}")] 
        public string SelectVideoPicById(int id)
        {
            VideoDB db = new VideoDB();
            string videoPic = db.SelectVideoPicById(id);
            return videoPic;
        }
        [HttpGet]
        [ActionName("MyLikesSelector")]
        public MyLikesList SelectAllMyLikes()
        {
            MyLikesDB db = new MyLikesDB();
            MyLikesList likes = db.SelectAll();
            return likes;
        }
    }
}
