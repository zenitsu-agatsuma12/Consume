using Consume.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Consume.Repository.RestApi
{
    public class InformationRestRepository : IInformationRepository
    {
        string baseURL = "https://jsonplaceholder.typicode.com";
        HttpClient httpClient = new HttpClient();
        public InformationRestRepository()
        {
        }

        public Information AddInformation(Information newInformation)
        {
            string data = JsonConvert.SerializeObject(newInformation);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(baseURL + "/todos", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                Information info = JsonConvert.DeserializeObject<Information>(responsecontent);
                return info;
            }
            return null;
        }

        public Information DeleteTodo(int id)
        {
            var response = httpClient.DeleteAsync(baseURL + "/todos/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                Information info = JsonConvert.DeserializeObject<Information>(data);
                return info;
            }
            return null;
        }

        public List<Information> GetAllInformation()
        {
            {
                var response = httpClient.GetAsync(baseURL + "/todos").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;

                    List<Information> todos = JsonConvert.DeserializeObject<List<Information>>(data);
                    return todos;
                }
                return null;
            }
        }

        public Information GetInformationById(int id)
        {
            var response = httpClient.GetAsync(baseURL + "/todos/" + id ).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                Information info = JsonConvert.DeserializeObject<Information>(data);
                return info;
            }
            return null;
        }

        public Information UpdateInformation(int id, Information newInformation)
        {
            string data = JsonConvert.SerializeObject(newInformation);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync(baseURL + "/todos/" + id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                Information info = JsonConvert.DeserializeObject<Information>(responsecontent);
                return info;
            }
            return null;
        }
    }
}
