using FetchFake_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FetchFake_API.Controllers
{
    public class HomeController : Controller
    {
        private string url = "https://jsonplaceholder.typicode.com/users";
        HttpClient client = new HttpClient();

        public IActionResult Index()
        {
            List<User> Users = new List<User>();

            HttpResponseMessage response = client.GetAsync(url).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<User>>(result);

            if (response.IsSuccessStatusCode)
            {
                Users = data;
            }
            return View(Users);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            var response = client.PostAsJsonAsync(url, user).Result;
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var response = client.GetAsync($"{url}/{id}").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<User>(result);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            var response = client.PutAsJsonAsync($"{url}/{id}", user).Result;
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            var response = client.GetAsync($"{url}/{id}").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<User>(result);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var response = client.DeleteAsync($"{url}/{id}").Result;
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }
    }
}
