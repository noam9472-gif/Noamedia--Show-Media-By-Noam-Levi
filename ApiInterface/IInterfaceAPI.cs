using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInterface
{
    public interface IInterfaceAPI
    {
        public Task<VideoList> GetAllVideos();
        public Task<int> DeleteVideo(int id);
        public Task<int> InsertVideo(Video video);
        public Task<int> UpdateVideo(Video video);

        public Task<UserList> GetAllUsers();
        public Task<int> DeleteUser(int id);
        public Task<int> InsertUser(User user);
        public Task<int> UpdateUser(User user);

        public Task<GenreList> GetAllGenres();
        public Task<int> DeleteGenre(int id);
        public Task<int> InsertGenre(Genre genre);
        public Task<int> UpdateGenre(Genre genre);

        public Task<VideoReviewList> GetAllVideoReviews();
        public Task<int> DeleteVideoReview(int id);
        public Task<int> InsertVideoReview(VideoReview videoReview);
        public Task<int> UpdateVideoReview(VideoReview videoReview);

        public Task<UserPremiumList> GetAllUserPremiums();
        public Task<int> DeleteUserPremium(int id);
        public Task<int> InsertUserPremium(UserPremium userPremium);
        public Task<int> UpdateUserPremium(UserPremium userPremium);

        public Task<AgeOfVideoList> GetAllAgeOfVideos();
        public Task<int> DeleteAgeOfVideo(int id);
        public Task<int> InsertAgeOfVideo(AgeOfVideos ageOfVideo);   
        public Task<int> UpdateAgeOfVideo(AgeOfVideos ageOfVideo);

        Task<string> GetVideoPicByte64(int id);
    }
}
