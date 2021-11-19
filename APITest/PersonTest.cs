using Microsoft.AspNetCore.Mvc;
using MockAPIService.Models;
using MockAPIService.Services;
using RandomSoftware.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace APITest
{
    public class PersonTest
    {
        private readonly PersonController _personController;
        private readonly IMockApiService _testService;

        public PersonTest()
        {
            _testService = new TestService();
            _personController = new PersonController(_testService);
        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange
            //Act1
            var result = _personController.Get();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<Person>>(list.Value);


            var personList = list.Value as List<Person>;

            Assert.Equal(2, personList.Count);
        }

        [Fact]
        public void CheckIsInShiftTrue()
        {
            var result = _testService.IsInShift(DateTime.Parse("2021-10-01 05:51:35.2379913"));
            Assert.Equal(true, result);
        }

        [Fact]
        public void CheckIsInShiftFalse()
        {
            var result = _testService.IsInShift(DateTime.Parse("2021-10-01 09:51:35.2379913"));

            Assert.Equal(true, result);
        }
    }
}
