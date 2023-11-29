using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FinalProj.Application.Contracts;
using FinalProj.Application.Core;
using FinalProj.Application.DTO_s.Venta;
using FinalProj.Web.Models.Responses;

namespace School.Web.Controllers
{
    public class VentaController : Controller
    {
        private readonly IVentaService ventaService;

        HttpClientHandler clientHandler = new HttpClientHandler();

        public VentaController(IVentaService ventaService)
        {
            this.ventaService = ventaService;
        }

        // GET: VentaController
        public ActionResult Index()
        {
            VentaListResponse ventaList = new VentaListResponse();


            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5240/api/Venta/GetVentas").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        ventaList = JsonConvert.DeserializeObject<VentaListResponse>(apiResponse);

                        if (!ventaList.success)
                        {
                            ViewBag.Message = ventaList.message;
                            return View();
                        }


                    }
                    else
                    {
                        ventaList.message = "Error conectandose al API.";
                        ventaList.success = false;
                        ViewBag.Message = ventaList.message;
                        return View();
                    }
                }
            }

            return View(ventaList.data);
        }

        // GET: VentaController/Details/5
        public ActionResult Details(int id)
        {

            VentaDetailResponse ventaDetailResponse = new VentaDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5240/api/Venta/GetVenta?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        ventaDetailResponse = JsonConvert.DeserializeObject<VentaDetailResponse>(apiResponse);

                        if (!ventaDetailResponse.success)
                            ViewBag.Message = ventaDetailResponse.message;


                    }
                }
            }


            return View(ventaDetailResponse.data);
        }

        // GET: VentaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VentaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VentaDTOAdd ventaDTOAdd)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5240/api/Venta/SaveVenta";

                    ventaDTOAdd.ChangeDate = DateTime.Now;
                    ventaDTOAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(ventaDTOAdd), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                            if (!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }

                        }
                        else
                        {
                            baseResponse.message = "Error conectandose al API.";
                            baseResponse.success = false;
                            ViewBag.Message = baseResponse.message;
                            return View();
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }
        }

        // GET: VentaController/Edit/5
        public ActionResult Edit(int id)
        {
            VentaDetailResponse ventaDetailResponse = new VentaDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5240/api/Venta/GetVenta?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        ventaDetailResponse = JsonConvert.DeserializeObject<VentaDetailResponse>(apiResponse);

                    }
                }
            }


            return View(ventaDetailResponse.data);
        }


        // POST: VentaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VentaDTOUpdate ventaDTOUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5214/api/Student/UpdateStudent";

                    ventaDTOUpdate.ChangeDate = DateTime.Now;
                    ventaDTOUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(ventaDTOUpdate), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                            if (!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }

                        }
                        else
                        {
                            ViewBag.Message = baseResponse.message;
                            return View();
                        }
                    }
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }
        }


    }
}