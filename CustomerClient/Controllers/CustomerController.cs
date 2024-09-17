using CustomerClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CustomerClient.Controllers
{
    public class CustomerController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7027");
        public readonly HttpClient client;
        public CustomerController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            List<CustomerViewModel> customers = new List<CustomerViewModel>();
            HttpResponseMessage response = client.GetAsync("api/Customers").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<CustomerViewModel>>(data);
            }
            return View(customers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/Customers",stringContent).Result;

                if(response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            CustomerViewModel customer = new CustomerViewModel();
            HttpResponseMessage response = client.GetAsync("api/Customers/" + id).Result;

            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<CustomerViewModel>(data);
            }

            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    string data = JsonConvert.SerializeObject(model);
                    StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("api/Customers/"+ id, stringContent).Result;
                    if(response.IsSuccessStatusCode)
                    { 
                        return RedirectToAction(nameof(Index)); 
                    }
                    return View();
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CustomerViewModel customer = new CustomerViewModel();
                HttpResponseMessage response = client.GetAsync("api/Customers/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    customer = JsonConvert.DeserializeObject<CustomerViewModel>(data);
                }

                return View(customer);
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("api/Customers/"+ id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
