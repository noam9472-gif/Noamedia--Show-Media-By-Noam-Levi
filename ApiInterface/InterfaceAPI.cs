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

                }
            }
            return st;
        }



        public async Task<VideoList> GetAllVideos()
        {
            return await client.GetFromJsonAsync<VideoList>(uri + "/api/Select/VideoSelector");
        }
        public async Task<int> DeleteVideo(int id)
        {
            // תיקון: החלפתי את DeleteUser ב-DeleteVideo כפי שמופיע ב-Swagger שלך
            var response = await client.DeleteAsync($"{uri}/api/Delete/DeleteVideo/VideoDeleter/{id}");

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return int.Parse(result);
            }
            return 0;
        }
        public async Task<int> InsertVideo(Video video)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Insert/VideoInserter", video)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateVideo(Video video)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Update/VideoUpdater", video)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<GenreList> GetAllGenres()
        {
            return await client.GetFromJsonAsync<GenreList>(uri + "/api/Select/GenreSelector");
        }
        public async Task<int> DeleteGenre(int id)
        {
            try
            {
                // שימוש בנתיב המדויק מה-Swagger ששלחת בתמונה
                var response = await client.DeleteAsync($"{uri}/api/Delete/DeleteGenre/DeleteGenre/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return int.Parse(result + 1);
                }
                else
                {
                    // הדפסה לדיבוג במידה וזה עדיין נכשל
                    System.Diagnostics.Debug.WriteLine($"API Error Genre: {response.StatusCode}");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("WPF Error Genre: " + ex.Message);
                return 0;
            }
        }
        public async Task<int> InsertGenre(Genre Genre)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Insert/GenreInserter", Genre)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateGenre(Genre Genre)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Update/GenreUpdater", Genre)).IsSuccessStatusCode ? 1 : 0;
        }
        // פונקציה אחת רק בשביל להביא את הרשימה (GET)
        public async Task<UserList> GetAllUsers()
        {
            return await client.GetFromJsonAsync<UserList>(uri + "/api/Select/UserSelector");
        }

        // פונקציה נפרדת רק בשביל המחיקה (DELETE)
        public async Task<int> DeleteUser(int id)
        {
            try
            {
                // הכתובת המדויקת שעבדה ב-Swagger שלך:
                // שים לב לתוספת של DeleteUser באמצע הנתיב
                var response = await client.DeleteAsync($"{uri}/api/Delete/DeleteUser/UserDeleter/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return int.Parse(result);
                }
                else
                {
                    // הדפסה לדיבוג כדי לראות איזו שגיאה השרת מחזיר (למשל 404)
                    System.Diagnostics.Debug.WriteLine($"Error: {response.StatusCode}");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("WPF Error: " + ex.Message);
                return 0;
            }
        }
        public async Task<int> InsertUser(User User)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Insert/UserInserter", User)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateUser(User User)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Update/UserUpdater", User)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<UserPremiumList> GetAllUserPremiums()
        {
            return await client.GetFromJsonAsync<UserPremiumList>(uri + "/api/Select/UserPremiumSelector");
        }
        public async Task<int> DeleteUserPremium(int id)
        {
            return (await client.DeleteAsync(uri + $"/api/Delete/UserPremiumDeleter/" + id)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> InsertUserPremium(UserPremium UserPremium)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Insert/UserPremiumInserter", UserPremium)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateUserPremium(UserPremium UserPremium)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Update/UserPremiumUpdater", UserPremium)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<VideoReviewList> GetAllVideoReviews()
        {
            try
            {
                var result = await client.GetFromJsonAsync<VideoReviewList>($"{uri}/api/Select/VideoReviewSelector");
                return result ?? new VideoReviewList(); // מחזיר רשימה ריקה במקום null אם אין נתונים
            }
            catch (Exception ex)
            {
                // הדפסה למסך הדיבוג כדי שתדע מה השתבש
                System.Diagnostics.Debug.WriteLine("API Error: " + ex.Message);
                return null;
            }
        }

        public async Task<List<VideoReview>> GetReviewsByVideoId(int videoId)// פונקציה שמחזירה רק את הביקורות של סרט ספציפי
        {
            // משיכת כל הביקורות לסרט הנ"ל
            VideoReviewList allReviews = await GetAllVideoReviews();

            if (allReviews == null) return new List<VideoReview>();

                // סינון כל הביקורות שלא קשורות לסרט הנ"ל
                return allReviews.Where(r => r.WhichVideoDidTheUserReview != null &&
                                         r.WhichVideoDidTheUserReview.Id == videoId).ToList();
        }
        public async Task<int> DeleteVideoReview(int reviewId)
        {
            try
            {
                // שיניתי את המילה DeleteReview השנייה ל-Review כדי להתאים ל-Swagger
                var response = await client.DeleteAsync($"{uri}/api/Delete/DeleteReview/Review/{reviewId}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return int.Parse(content);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"API Error (DeleteReview): {response.StatusCode}");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("WPF Error (DeleteReview): " + ex.Message);
                return 0;
            }
        }
        public async Task<int> InsertVideoReview(VideoReview VideoReview)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Insert/VideoReviewInserter", VideoReview)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateVideoReview(VideoReview VideoReview)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Update/VideoReviewUpdater", VideoReview)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<AgeOfVideoList> GetAllAgeOfVideos()
        {
            return await client.GetFromJsonAsync<AgeOfVideoList>(uri + "/api/Select/AgeOfVideoSelector");
        }
        public async Task<int> DeleteAgeOfVideo(int id)
        {
            return (await client.DeleteAsync(uri + $"/api/Delete/AgeOfVideoDeleter/" + id)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> InsertAgeOfVideo(AgeOfVideos AgeOfVideo)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Insert/AgeOfVideoInserter", AgeOfVideo)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateAgeOfVideo(AgeOfVideos AgeOfVideo)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Update/AgeOfVideoUpdater", AgeOfVideo)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<MyLikesList> GetAllLikes()
        {
            return await client.GetFromJsonAsync<MyLikesList>(uri + "/api/Select/MyLikesSelector");
        }
        public async Task<int> InsertLike(MyLikes like)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Insert/MyLikesInserter", like)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteLike(int id)
        {
            var response = await client.DeleteAsync($"{uri}/api/Delete/MyLikesDeleter/{id}");
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<bool> IsUserPremium(int id)
        {
            UserPremiumList premiumList = await GetAllUserPremiums();
            // בדיקה אם קיים אובייקט ברשימה שה-ID שלו תואם ל-ID שקיבלנו
            return premiumList != null && premiumList.Any(p => p.Id == id);
        }


        public async Task<bool> CheckIfUserLikedVideo(int userId, int videoId)
        {
            // אנחנו מושכים את כל הלייקים ובודקים אם קיים שילוב של המשתמש והסרט
            // זו הדרך הכי בטוחה אם עדיין אין לך Endpoint ייעודי בשרת
            MyLikesList allLikes = await GetAllLikes();
            return allLikes != null && allLikes.Any(l => l.UserId.Id == userId && l.VideoId.Id == videoId);
        }

        public async Task<bool> AddLike(MyLikes likes)
        {
            try
            {

                var response = await client.PostAsJsonAsync(uri + "/api/Insert/MyLikesInserter", likes);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"API Error: {response.StatusCode} - {error}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in AddLike: {ex.Message}");
                return false;
            }
        }

        public async Task<int> DeleteAllReviewsByUser(int userId)
        {
            try
            {
                // 1. נשלוף את כל הביקורות הקיימות במערכת
                VideoReviewList allReviews = await GetAllVideoReviews();

                if (allReviews == null) return 1; // אם אין ביקורות בכלל, הכל תקין

                // 2. נסנן רק את הביקורות ששייכות למשתמש הספציפי
                var userReviews = allReviews.Where(r => r.WhoUpdatedTheReview != null && r.WhoUpdatedTheReview.Id == userId).ToList();

                // 3. נמחק ביקורת ביקורת
                foreach (var review in userReviews)
                {
                    await DeleteVideoReview(review.Id);
                }

                return 1; // הצלחה
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error deleting user reviews: " + ex.Message);
                return 0;
            }
        }
        public async Task<int> MoveMoviesBetweenGenres(int fromId, int toId)
        {
            try
            {
                // שינוי הכתובת לפי ה-Swagger ששלחת: הוספת MoveMovies פעמיים
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


        public async Task<int> UpdateSingleMovieGenre(int videoId, int newGenreId)
        {
            try
            {
                // שימוש בנתיב הכפול לפי ה-Swagger: api/Update/UpdateMovieGenre/UpdateMovieGenre
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

        public async Task<bool> RemoveLike(int userId, int videoId)
        {
            // כאן צריך למצוא את ה-ID של הלייק הספציפי כדי למחוק אותו
            MyLikesList allLikes = await GetAllLikes();
            var likeToDelete = allLikes?.FirstOrDefault(l => l.UserId.Id == userId && l.VideoId.Id == videoId);

            if (likeToDelete != null)
            {
                return await DeleteLike(likeToDelete.Id) == 1;
            }
            return false;
        }
        public async Task<MyWatchListList> GetAllMyWatchList()
        {
            return await client.GetFromJsonAsync<MyWatchListList>(uri + "/api/Select/MyWatchListSelector");
        }
        public async Task<int> InsertMyWatchList(MyWatchList like)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Insert/MyWatchListInserter", like)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteMyWatchList(int id)
        {
            var response = await client.DeleteAsync($"{uri}/api/Delete/MyWatchListDeleter/{id}");
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<MyHistoryList> GetAllMyHistory()
        {
            return await client.GetFromJsonAsync<MyHistoryList>(uri + "/api/Select/MyHistorySelector");
        }
        public async Task<int> InsertMyHistory(MyHistory like)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Insert/MyHistoryInserter", like)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteMyHistory(int id)
        {
            var response = await client.DeleteAsync($"{uri}/api/Delete/MyHistoryDeleter/{id}");
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<bool> CheckIfUserInWatchList(int userId, int videoId)
        {
            // כאן צריכה להיות הקריאה לשרת שלך (Web API או ישירות ל-DB)
            // דוגמה:
            var allWatchList = await GetAllMyWatchList();
            return allWatchList.Any(w => w.UserId.Id == userId && w.VideoId.Id == videoId);
        }

        public async Task<bool> DeleteMyWatchList(int userId, int videoId)
        {
            try
            {
                // 1. קודם כל נמצא את ה-ID של הרשומה ב-WatchList כדי שנוכל למחוק אותה
                var allWatchList = await GetAllMyWatchList();
                var itemToDelete = allWatchList?.FirstOrDefault(w => w.UserId.Id == userId && w.VideoId.Id == videoId);

                if (itemToDelete != null)
                {
                    // 2. נשתמש בנתיב המלא ובפונקציית המחיקה הקיימת שכבר עובדת לך (DeleteMyWatchList המקורית שמקבלת ID)
                    // שימוש ב-uri ובנתיב ה-api המלא כפי שמופיע בשאר הפונקציות שלך
                    string fullUrl = $"{uri}/api/Delete/MyWatchListDeleter/{itemToDelete.Id}";
                    var response = await client.DeleteAsync(fullUrl);

                    return response.IsSuccessStatusCode;
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting from watchlist: {ex.Message}");
                return false;
            }
        }
        public async Task<int> ForceClearVideo(int videoId)
        {
            try
            {
                // 1. מחיקת כל ה-VideoReview של הסרטון הזה
                var allReviews = await GetAllVideoReviews();
                var targetReviews = allReviews.Where(r => r.WhichVideoDidTheUserReview?.Id == videoId).ToList();
                foreach (var review in targetReviews)
                {
                    await DeleteVideoReview(review.Id);
                }

                // 2. מחיקת כל הלייקים (MyLikes) של הסרטון הזה
                var allLikes = await GetAllLikes();
                var targetLikes = allLikes.Where(l => l.VideoId?.Id == videoId).ToList();
                foreach (var like in targetLikes)
                {
                    await DeleteLike(like.Id);
                }

                return 1;
            }
            catch { return 0; }
        }
        public async Task<int> ForceClearUserEverything(int userId)
        {
            try
            {
                // 1. ניקוי ביקורות
                var reviews = await GetAllVideoReviews();
                if (reviews != null)
                {
                    foreach (var r in reviews.Where(x => x.WhoUpdatedTheReview?.Id == userId))
                        await DeleteVideoReview(r.Id);
                }

                // 2. ניקוי לייקים
                var likes = await GetAllLikes();
                if (likes != null)
                {
                    foreach (var l in likes.Where(x => x.UserId?.Id == userId))
                        await DeleteLike(l.Id);
                }



                // 4. ניקוי פרימיום
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
