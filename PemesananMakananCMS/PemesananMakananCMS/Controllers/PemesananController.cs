using Newtonsoft.Json;
using PemesananMakananCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace PemesananMakananCMS.Controllers
{
    public class PemesananController : Controller
    {
        // GET: Pemesanan
        public ActionResult Index()
        {
            PemesananModels result = GetPemesananList();
            return View(result);
        }

        public PemesananModels GetPemesananList()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5277/api/Pemesanan/GetPemesananList");

            // Add an Accept header for JSON format.
            httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = httpClient.GetAsync("").Result;
            // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = JsonConvert.DeserializeObject<PemesananModels>(response.Content.ReadAsStringAsync().Result);

                return dataObjects;
            }
            else
            {
                return null;
            }

        }

        // GET: Pemesanan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pemesanan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pemesanan/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pemesanan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pemesanan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pemesanan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pemesanan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
