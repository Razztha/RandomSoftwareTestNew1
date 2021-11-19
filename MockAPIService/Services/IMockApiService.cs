using MockAPIService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockAPIService.Services
{
    public interface IMockApiService
    {
        public Task<List<Person>> GetAllPersons();
        public Task<Person> GetPersonById(int id);
        public Task<List<Post>> GetAllPosts();
        public bool IsInShift(DateTime time);
    }
}
