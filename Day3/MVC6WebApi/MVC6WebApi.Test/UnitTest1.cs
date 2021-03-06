using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;



namespace MVC6WebApi.Test
{
    public class StudentControllerTest
    {
        // arrange
        private readonly Models.StudentDataContext _context;
        Controllers.StudentController _controller;
        Models.IStudentService _service;



        public StudentControllerTest()
        {
            _service = new Models.StudentService(_context);
            _controller = new Controllers.StudentController(_service);
        }




        [Fact]
        public void Get_WhenCalled_ReturnsOkresult()
        {
            // act
            var okResult = _controller.GetStudents();



            // assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}