using MockAPIService.Models;
using MockAPIService.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MockAPIService
{
    public class MockApiService : IMockApiService
    {
        public async Task<List<Person>> GetAllPersons()
        {
            List<Person> personList = new List<Person>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://6197551caf46280017e7e53a.mockapi.io/Person"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    personList = JsonConvert.DeserializeObject<List<Person>>(apiResponse);
                }
            }
            return personList;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            List<Post> postList = new List<Post>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://6197551caf46280017e7e53a.mockapi.io/Post"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    postList = JsonConvert.DeserializeObject<List<Post>>(apiResponse);
                }
            }
            return postList;
        }

        public async Task<Person> GetPersonById(int id)
        {
            Person person = new Person();
            using (var httpClient = new HttpClient())
            {
                var url = "https://6197551caf46280017e7e53a.mockapi.io/Person/" + id;
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    person = JsonConvert.DeserializeObject<Person>(apiResponse);
                }
            }
            return person;
        }

        public bool IsInShift(DateTime time)
        {
            throw new NotImplementedException();
        }
    }
}
