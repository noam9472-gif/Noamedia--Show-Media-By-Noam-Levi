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
            return (await client.DeleteAsync(uri + $"/api/Delete/VideoDeleter/" + id)).IsSuccessStatusCode ? 1 : 0;
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
            return (await client.DeleteAsync(uri + $"/api/Delete/GenreDeleter/" + id)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> InsertGenre(Genre Genre)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Insert/GenreInserter", Genre)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateGenre(Genre Genre)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Update/GenreUpdater", Genre)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<UserList> GetAllUsers()
        {
            return await client.GetFromJsonAsync<UserList>(uri + "/api/Select/UserSelector");
        }
        public async Task<int> DeleteUser(int id)
        {
            return (await client.DeleteAsync(uri + $"/api/Delete/UserDeleter/" + id)).IsSuccessStatusCode ? 1 : 0;
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
            return await client.GetFromJsonAsync<VideoReviewList>(uri + "/api/Select/VideoReviewSelector");
        }
        public async Task<int> DeleteVideoReview(int id)
        {
            return (await client.DeleteAsync(uri + $"/api/Delete/VideoReviewDeleter/" + id)).IsSuccessStatusCode ? 1 : 0;
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
            // ב-DeleteController שלך הפונקציה מצפה ל-ID בנתיב (URL)
            return (await client.DeleteAsync(uri + $"/api/Delete/MyLikesDeleter/" + id)).IsSuccessStatusCode ? 1 : 0;
        }
    }
}
