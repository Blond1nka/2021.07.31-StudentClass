using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentClass.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudentClass.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MySqlConnection _connection;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _connection = connection;
        }

        public IActionResult Index()
        {
            _connection.Open();

            List<StudentModel> models = new();

            using var command = new MySqlCommand("SELECT * FROM students;", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                StudentModel model = new()
                {
                    Id = reader.GetInt(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2),
                    StudentClass_Id = reader.GetInt(3)
                };

                models.Add(model);
                var value = reader.GetValue(3);
                // do something with 'value'
            }

            _connection.Close();

            _connection.Open();

            // Insert
            using var command2 = new MySqlCommand(
            " insert into myguests (firstname, lastname, email) values('test3', 'test3', 'testemail3')", _connection);
            command2.ExecuteNonQuery();


            _connection.Close();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
