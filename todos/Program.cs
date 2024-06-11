// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UserInfoApp
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please provide the user email as a parameter.");
                return;
            }

            string userEmail = args[0];

            try
            {
                var users = await FetchData<List<User>>("https://jsonplaceholder.typicode.com/users");
                var todos = await FetchData<List<ToDo>>("https://jsonplaceholder.typicode.com/todos");

                var user = users.FirstOrDefault(u => u.Email?.Equals(userEmail, StringComparison.OrdinalIgnoreCase) ?? false);

                if (user == null)
                {
                    Console.WriteLine("User not found.");
                    return;
                }

                var userTodos = todos.Where(t => t.UserId == user.Id).ToList();

                var result = new
                {
                    id = user.Id,
                    name = user.Name,
                    username = user.Username,
                    email = user.Email,
                    address = new
                    {
                        street = user.Address?.Street,
                        suite = user.Address?.Suite,
                        city = user.Address?.City,
                        zipcode = user.Address?.Zipcode,
                        geo = new
                        {
                            lat = user.Address?.Geo?.Lat,
                            lng = user.Address?.Geo?.Lng
                        }
                    },
                    phone = user.Phone,
                    website = user.Website,
                    todos = userTodos
                };

                string json = JsonConvert.SerializeObject(result, Formatting.Indented);
                File.WriteAllText("user_info.json", json);

                Console.WriteLine("User information and ToDos have been written to user_info.json.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static async Task<T> FetchData<T>(string url)
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseBody)!;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public Address? Address { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public Company? Company { get; set; }
    }

    public class Address
    {
        public string? Street { get; set; }
        public string? Suite { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
        public Geo? Geo { get; set; }
    }

    public class Geo
    {
        public string? Lat { get; set; }
        public string? Lng { get; set; }
    }

    public class Company
    {
        public string? Name { get; set; }
        public string? CatchPhrase { get; set; }
        public string? Bs { get; set; }
    }

    public class ToDo
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool Completed { get; set; }
    }
}
