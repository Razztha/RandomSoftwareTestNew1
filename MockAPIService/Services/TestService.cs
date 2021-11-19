using MockAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockAPIService.Services
{
    public class TestService : IMockApiService
    {
        public async Task<List<Person>> GetAllPersons()
        {
            List<Person> personList = new List<Person>();
            personList.Add(new Person { Id = 111, Email = "hfdf", FirstName = "ui", LastName = "jdkf" });
            personList.Add(new Person { Id = 111, Email = "hfdf", FirstName = "ui", LastName = "jdkf" });
            return personList;
        }

        public Task<Person> GetPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsInShift(DateTime time)
        {
            TimeSpan start = TimeSpan.Parse("22:00");  // 10 PM
            TimeSpan end = TimeSpan.Parse("6:00");    // 6 AM
            TimeSpan now = time.TimeOfDay;

            bool bMatched = now >= start &&
                            now < end;
            if (end < start)
                bMatched = !bMatched;

            if (bMatched)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        Task<List<Post>> IMockApiService.GetAllPosts()
        {
            throw new NotImplementedException();
        }
    }
}
