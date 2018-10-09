using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace TryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public class Person
        {
            public string Name {get;set;}
            public string Surname {get;set;}
        }

        public class PersonFiller 
        {
            public Person Fill(MySqlDataReader reader) 
            {
                return new Person {
                        Name = reader["name"].ToString(),
                        Surname = reader["name"].ToString()
                };
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            using(var connection = new MySqlConnection("server=127.0.0.1;user id=root;password=password;port=3306;database=prova;"))
            {
                var command = new MySqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "select * from people";
                var reader = command.ExecuteReader();
                var people = new List<Person>();
                var filler = new PersonFiller();
                while(reader.Read()) 
                {
                    people.Add(filler.Fill(reader));
                }
                return people;
            }
        }
    }
}
