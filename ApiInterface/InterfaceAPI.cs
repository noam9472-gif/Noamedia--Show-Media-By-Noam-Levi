using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Model;
using ViewModel;
using System.Text.Json;
using System.Net.Http;

namespace ApiInterface
{
    public class InterfaceAPI : IInterfaceAPI
    {
        string uri;
        public HttpClient client;

        public InterfaceAPI()
        {
            uri = "http://localhost:5113";
            client = new HttpClient();
        }
        public async Task<string> GetVideoPicByte64(int id)
        {
            string st = null;
            string URI = $"{uri}/api/Select/VideoPicSelector64Byte/{id}";
            HttpResponseMessage response = await client.GetAsync(URI);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                try
                {
                    st = JsonSerializer.Deserialize<string>(json);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("JSON Error: " + ex.Message);
                }
            }
            return st;
        }

        public async Task<VideoList> GetAllVideos()
        {
            return await client.GetFromJsonAsync<VideoList>(uri + "/api/Select/VideoSelector");
        }

        public async Task<GenreList> GetAllGenres()
        {
            return await client.GetFromJsonAsync<GenreList>(uri + "/api/Select/GenreSelector");
        }

        public async Task<UserList> GetAllUsers()
        {
            return await client.GetFromJsonAsync<UserList>(uri + "/api/Select/UserSelector");
        }

        public async Task<UserPremiumList> GetAllUserPremiums()
        {
            return await client.GetFromJsonAsync<UserPremiumList>(uri + "/api/Select/UserPremiumSelector");
        }

        public async Task<VideoReviewList> GetAllVideoReviews()
        {
            try
            {
                var result = await client.GetFromJsonAsync<VideoReviewList>($"{uri}/api/Select/VideoReviewSelector");
                return result ?? new VideoReviewList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("API Error: " + ex.Message);
                return null;
            }
        }

        public async Task<MyLikesList> GetAllLikes()
        {
            return await client.GetFromJsonAsync<MyLikesList>(uri + "/api/Select/MyLikesSelector");
        }

        public async Task<MyWatchListList> GetAllMyWatchList()
        {
            return await client.GetFromJsonAsync<MyWatchListList>(uri + "/api/Select/MyWatchListSelector");
        }

        public async Task<MyHistoryList> GetAllMyHistory()
        {
            return await client.GetFromJsonAsync<MyHistoryList>(uri + "/api/Select/MyHistorySelector");
        }

        public async Task<int> InsertVideo(Video video)
        {
            var response = await client.PostAsJsonAsync($"{uri}/api/Insert/VideoInserter", video);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertUser(User User)
        {
            var response = await client.PostAsJsonAsync($"{uri}/api/Insert/UserInserter", User);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertGenre(Genre genre)
        {
            var response = await client.PostAsJsonAsync($"{uri}/api/Insert/InserterGenre", genre);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertVideoReview(VideoReview VideoReview)
        {
            var response = await client.PostAsJsonAsync($"{uri}/api/Insert/VideoReviewInserter", VideoReview);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertUserPremium(UserPremium userPremium)
        {
            var response = await client.PostAsJsonAsync($"{uri}/api/Insert/UserPremiumInserter", userPremium);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertLike(MyLikes like)
        {
            var response = await client.PostAsJsonAsync($"{uri}/api/Insert/MyLikesInserter", like);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertMyWatchList(MyWatchList item)
        {
            var response = await client.PostAsJsonAsync($"{uri}/api/Insert/MyWatchListInserter", item);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertMyHistory(MyHistory item)
        {
            var response = await client.PostAsJsonAsync($"{uri}/api/Insert/MyHistoryInserter", item);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateVideo(Video video)
        {
            var response = await client.PutAsJsonAsync(uri + "/api/Update/VideoUpdater", video);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateGenre(Genre Genre)
        {
            var response = await client.PutAsJsonAsync(uri + "/api/Update/GenreUpdater", Genre);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateUser(User User)
        {
            var response = await client.PutAsJsonAsync(uri + "/api/Update/UserUpdater", User);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateVideoReview(VideoReview VideoReview)
        {
            var response = await client.PutAsJsonAsync(uri + "/api/Update/VideoReviewUpdater", VideoReview);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateUserPremium(UserPremium userPremium)
        {
            var response = await client.PutAsJsonAsync(uri + "/api/Update/UserPremiumUpdater", userPremium);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateSingleMovieGenre(int videoId, int newGenreId) // פונקציה שמקבלת מזהה של סרט ומזהה של ז'אנר חדש ומעדכנת את הז'אנר של הסרט לז'אנר החדש
        {
            try
            {
                var response = await client.PutAsync($"{uri}/api/Update/UpdateMovieGenre/UpdateMovieGenre/{videoId}/{newGenreId}", null);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return int.Parse(result);
                }
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("API Error (Update Genre): " + ex.Message);
                return 0;
            }
        }

        public async Task<int> MoveMoviesBetweenGenres(int fromId, int toId) // פונקציה שמקבלת שני מזהים של ז'אנרים ומעבירה את כל הסרטים מהז'אנר הישן לחדש
        {
            try
            {
                var response = await client.PutAsync($"{uri}/api/Update/MoveMovies/MoveMovies/{fromId}/{toId}", null);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return int.Parse(content);
                }
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("API ERROR: " + ex.Message);
                return 0;
            }
        }

        public async Task<int> UpgradeUserToPremium(int userId)
        {
            try
            {
                var response = await client.PutAsync($"{uri}/api/Update/UpdateToPremium/{userId}", null);

                if (response.IsSuccessStatusCode) // אם הבקשה הצליחה, נניח שהשדרוג בוצע בהצלחה
                {
                    return 1;
                }
                return 0; // אם הבקשה לא הצליחה, נחזיר 0
            }
            catch (Exception ex) // טיפול בשגיאות אפשריות
            {
                System.Diagnostics.Debug.WriteLine("Upgrade Error: " + ex.Message);
                return 0;
            }
        }
        public async Task<int> DeleteVideo(int id)
        {
            var response = await client.DeleteAsync($"{uri}/api/Delete/DeleteVideo/VideoDeleter/{id}");
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return int.Parse(result);
            }
            return 0;
        }

        public async Task<int> DeleteGenre(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"{uri}/api/Delete/DeleteGenre/DeleteGenre/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return int.Parse(result);
                }
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("WPF Error Genre: " + ex.Message);
                return 0;
            }
        }

        public async Task<int> DeleteUser(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"{uri}/api/Delete/DeleteUser/UserDeleter/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return int.Parse(result);
                }
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("WPF Error: " + ex.Message);
                return 0;
            }
        }

        public async Task<int> DeleteUserPremium(int id)
        {
            var response = await client.DeleteAsync(uri + $"/api/Delete/UserPremiumDeleter/" + id);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteVideoReview(int reviewId)
        {
            try
            {
                var response = await client.DeleteAsync($"{uri}/api/Delete/DeleteReview/Review/{reviewId}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return int.Parse(content);
                }
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("WPF Error (DeleteReview): " + ex.Message);
                return 0;
            }
        }

        public async Task<int> DeleteLike(int id)
        {
            var response = await client.DeleteAsync($"{uri}/api/Delete/MyLikesDeleter/{id}");
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteMyWatchList(int id)
        {
            var response = await client.DeleteAsync($"{uri}/api/Delete/MyWatchListDeleter/{id}");
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteMyHistory(int id)
        {
            var response = await client.DeleteAsync($"{uri}/api/Delete/MyHistoryDeleter/{id}");
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<List<VideoReview>> GetReviewsByVideoId(int videoId)
        {
            VideoReviewList allReviews = await GetAllVideoReviews();
            if (allReviews == null) return new List<VideoReview>();

            return allReviews.Where(r => r.WhichVideoDidTheUserReview != null &&
                                         r.WhichVideoDidTheUserReview.Id == videoId).ToList();
        }

        public async Task<bool> IsUserPremium(int id)
        {
            UserList userList = await GetAllUsers();
            var user = userList?.FirstOrDefault(u => u.Id == id);
            return user != null && user.IsPremium;
        }

        public async Task<bool> CheckIfUserLikedVideo(int userId, int videoId)
        {
            MyLikesList allLikes = await GetAllLikes();
            return allLikes != null && allLikes.Any(l => l.UserId.Id == userId && l.VideoId.Id == videoId);
        }

        public async Task<bool> AddLike(MyLikes likes)
        {
            return await InsertLike(likes) == 1;
        }

        public async Task<bool> RemoveLike(int userId, int videoId)
        {
            MyLikesList allLikes = await GetAllLikes();
            var likeToDelete = allLikes?.FirstOrDefault(l => l.UserId.Id == userId && l.VideoId.Id == videoId);
            if (likeToDelete != null)
            {
                return await DeleteLike(likeToDelete.Id) == 1;
            }
            return false;
        }

        public async Task<bool> CheckIfUserInWatchList(int userId, int videoId)
        {
            var allWatchList = await GetAllMyWatchList();
            return allWatchList != null && allWatchList.Any(w => w.UserId.Id == userId && w.VideoId.Id == videoId);
        }

        public async Task<bool> DeleteMyWatchList(int userId, int videoId)
        {
            try
            {
                var allWatchList = await GetAllMyWatchList();
                var itemToDelete = allWatchList?.FirstOrDefault(w => w.UserId.Id == userId && w.VideoId.Id == videoId);

                if (itemToDelete != null)
                {
                    return await DeleteMyWatchList(itemToDelete.Id) == 1;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting from watchlist: {ex.Message}");
                return false;
            }
        }

        public async Task<int> GetCommentsCountByUser(int userId) // פונקציה שמחזירה כמה ביקורות משתמש נתון כתב על מנת שיקבל פרימיום
        {
            var allReviews = await GetAllVideoReviews();
            if (allReviews == null) return 0;
            return allReviews.Count(r => r.WhoUpdatedTheReview != null && r.WhoUpdatedTheReview.Id == userId);
        }

        public async Task<int> GetLikesCountByUser(int userId) // פונקציה שמחזירה כמה לייקים משתמש נתון נתן על מנת שיקבל פרימיום
        {
            var allLikes = await GetAllLikes();
            if (allLikes == null) return 0;
            return allLikes.Count(l => l.UserId != null && l.UserId.Id == userId);
        }

        public async Task<int> DeleteAllReviewsByUser(int userId)
        {
            try
            {
                VideoReviewList allReviews = await GetAllVideoReviews();
                if (allReviews == null) return 1;

                var userReviews = allReviews.Where(r => r.WhoUpdatedTheReview != null && r.WhoUpdatedTheReview.Id == userId).ToList();
                foreach (var review in userReviews)
                {
                    await DeleteVideoReview(review.Id);
                }
                return 1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error deleting user reviews: " + ex.Message);
                return 0;
            }
        }

        public async Task<int> ForceClearVideo(int videoId)
        {
            try
            {
                var allReviews = await GetAllVideoReviews();
                var targetReviews = allReviews.Where(r => r.WhichVideoDidTheUserReview?.Id == videoId).ToList();
                foreach (var review in targetReviews) await DeleteVideoReview(review.Id);

                var allLikes = await GetAllLikes();
                var targetLikes = allLikes.Where(l => l.VideoId?.Id == videoId).ToList();
                foreach (var like in targetLikes) await DeleteLike(like.Id);

                return 1;
            }
            catch { return 0; }
        }

        public async Task<int> ForceClearUserEverything(int userId)
        {
            try
            {
                var reviews = await GetAllVideoReviews();
                if (reviews != null)
                {
                    foreach (var r in reviews.Where(x => x.WhoUpdatedTheReview?.Id == userId))
                        await DeleteVideoReview(r.Id);
                }

                var likes = await GetAllLikes();
                if (likes != null)
                {
                    foreach (var l in likes.Where(x => x.UserId?.Id == userId))
                        await DeleteLike(l.Id);
                }

                await DeleteUserPremium(userId);
                return 1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Force clear failed: " + ex.Message);
                return 0;
            }
        }
    }
}