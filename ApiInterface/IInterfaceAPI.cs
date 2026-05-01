using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;

namespace ApiInterface
{
    public interface IInterfaceAPI
    {
        // Videos
        Task<VideoList> GetAllVideos();
        Task<string> GetVideoPicByte64(int id);
        Task<int> InsertVideo(Video video);
        Task<int> UpdateVideo(Video video);
        Task<int> DeleteVideo(int id);
        Task<int> ForceClearVideo(int videoId);

        // Genres
        Task<GenreList> GetAllGenres();
        Task<int> InsertGenre(Genre genre);
        Task<int> UpdateGenre(Genre genre);
        Task<int> DeleteGenre(int id);
        Task<int> MoveMoviesBetweenGenres(int fromId, int toId);
        Task<int> UpdateSingleMovieGenre(int videoId, int newGenreId);

        // Users
        Task<UserList> GetAllUsers();
        Task<int> InsertUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> DeleteUser(int id);
        Task<int> ForceClearUserEverything(int userId);
        // פעולה שמעדכנת את הסטטוס של המשתמש לפרימיום
        Task<int> UpgradeUserToPremium(int userId);

        Task<int> InsertUserPremium(UserPremium userPremium);
        Task<int> UpdateUserPremium(UserPremium userPremium);

        Task<bool> IsUserPremium(int id);
        Task<UserPremiumList> GetAllUserPremiums();
        Task<int> DeleteUserPremium(int id);

        // Reviews
        Task<VideoReviewList> GetAllVideoReviews();
        Task<List<VideoReview>> GetReviewsByVideoId(int videoId);
        Task<int> InsertVideoReview(VideoReview videoReview);
        Task<int> UpdateVideoReview(VideoReview videoReview);
        Task<int> DeleteVideoReview(int reviewId);
        Task<int> DeleteAllReviewsByUser(int userId);
        Task<int> GetCommentsCountByUser(int userId);

        // Likes
        Task<MyLikesList> GetAllLikes();
        Task<int> InsertLike(MyLikes like);
        Task<int> DeleteLike(int id);
        Task<bool> CheckIfUserLikedVideo(int userId, int videoId);
        Task<bool> AddLike(MyLikes likes);
        Task<bool> RemoveLike(int userId, int videoId);
        Task<int> GetLikesCountByUser(int userId);

        // WatchList
        Task<MyWatchListList> GetAllMyWatchList();
        Task<int> InsertMyWatchList(MyWatchList item);
        Task<int> DeleteMyWatchList(int id);
        Task<bool> CheckIfUserInWatchList(int userId, int videoId);
        Task<bool> DeleteMyWatchList(int userId, int videoId);

        // History
        Task<MyHistoryList> GetAllMyHistory();
        Task<int> InsertMyHistory(MyHistory item);
        Task<int> DeleteMyHistory(int id);
    }
}