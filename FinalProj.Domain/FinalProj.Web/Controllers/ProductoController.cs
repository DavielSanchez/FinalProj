using FinalProj.Web.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FinalProj.Web.Controllers
{
    public class ProductoController : Controller
    {
        public class ProductoController : Controller
        {
            private readonly IProductoService productoService;
            private readonly IApiService apiService;
            private readonly IHttpClientFactory httpClientFactory;

            HttpClientHandler clientHandler = new HttpClientHandler();

            private const string BaseApiUrl = "http://localhost:5240/api/Producto/";

            public ProductoController(IProductoService productoService, IApiService apiService)
            {
                this.productoService = productoService;
                this.apiService = apiService;
            }

            public async Task<ActionResult> Index()
            {
                var productoList = await apiService.GetProductos();

                if (!productoList.success)
                {
                    ViewBag.Message = productoList.message;
                    return View();
                }

                return View(productoList.data);
            }

            public async Task<ActionResult> Details(int id)
            {
                var productoDetailResponse = await apiService.GetProducto(id);

                if (!productoDetailResponse.success)
                {
                    ViewBag.Message = productoDetailResponse.message;
                    return View();
                }

                return View(productoDetailResponse.data);
            }

            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create(ProductoDTOAdd productoDTOAdd)
            {
                var baseResponse = await apiService.SaveProducto(productoDTOAdd);

                if (!baseResponse.success)
                {
                    ViewBag.Message = baseResponse.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }

            public async Task<ActionResult> Edit(int id)
            {
                var productoDetailResponse = await apiService.GetProducto(id);

                if (!productoDetailResponse.success)
                {
                    ViewBag.Message = productoDetailResponse.message;
                    return View();
                }

                return View(productoDetailResponse.data);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit(ProductoDTOUpdate productoDTOUpdate)
            {
                var baseResponse = await apiService.UpdateProducto(productoDTOUpdate);

                if (!baseResponse.success)
                {
                    ViewBag.Message = baseResponse.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
