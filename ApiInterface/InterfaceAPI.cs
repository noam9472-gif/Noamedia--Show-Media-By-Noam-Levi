using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInterface
{
    public class InterfaceAPI : IInterfaceAPI
    {
        string uri;
        public HttpClient client;
        public ApiService()
        {
                       uri = "https://localhost:5115";
            client = new HttpClient();
        }

        public async Task<VideoList> GetAllVideos()
        {
            return await client.GetFromJsonAsync<VideoList>(uri + "/api/Insert/VideoSelector");
        }
        public async Task<int> DeleteVideo(int id)
        {
            return (await client.DeleteAsync(uri + $"/api/Insert/DeleteVideo/"id)).IsSuccessStatusCode ? 1:0 ;
        }
        public async Task<int> InsertVideo(Video video)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Insert/InsertVideo", video)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateVideo(Video video)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Insert/UpdateVideo", video)).IsSuccessStatusCode ? 1 : 0;
        }
    }
}
