using Microsoft.AspNetCore.Mvc;
using FinalProj.Application.Contracts;
using FinalProj.Application.DTO_s.Venta;
using FinalProj.Web.Contracts;

namespace School.Web.Controllers
{
    public class VentaController : Controller
    {
        private readonly IVentaService ventaService;
        private readonly IApiService apiService;
        private readonly IHttpClientFactory httpClientFactory;

        HttpClientHandler clientHandler = new HttpClientHandler();

        private const string BaseApiUrl = "http://localhost:5240/api/Venta/";

        public VentaController(IVentaService ventaService, IApiService apiService)
        {
            this.ventaService = ventaService;
            this.apiService = apiService;
        }

        public async Task<ActionResult> Index()
        {
            var ventaList = await apiService.GetVentas();

            if (!ventaList.success)
            {
                ViewBag.Message = ventaList.message;
                return View();
            }

            return View(ventaList.data);
        }

        public async Task<ActionResult> Details(int id)
        {
            var ventaDetailResponse = await apiService.GetVenta(id);

            if (!ventaDetailResponse.success)
            {
                ViewBag.Message = ventaDetailResponse.message;
                return View();
            }

            return View(ventaDetailResponse.data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VentaDTOAdd ventaDTOAdd)
        {
            var baseResponse = await apiService.SaveVenta(ventaDTOAdd);

            if (!baseResponse.success)
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id)
        {
            var ventaDetailResponse = await apiService.GetVenta(id);

            if (!ventaDetailResponse.success)
            {
                ViewBag.Message = ventaDetailResponse.message;
                return View();
            }

            return View(ventaDetailResponse.data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VentaDTOUpdate ventaDTOUpdate)
        {
            var baseResponse = await apiService.UpdateVenta(ventaDTOUpdate);

            if (!baseResponse.success)
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}