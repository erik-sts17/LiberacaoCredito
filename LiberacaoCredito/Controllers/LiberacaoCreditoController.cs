using Domain.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace LiberacaoCredito.Controllers
{
    public class LiberacaoCreditoController : Controller
    {
        [HttpGet ("[action]")]
        public IActionResult LiberarCredito([FromQuery] LiberacaoCreditoRequestViewModel liberacaoCreditoRequestViewModel)
        {
            var service = new LiberacaoCreditoService();
            var result = service.LiberarCredito(liberacaoCreditoRequestViewModel);
            return Ok(result);
        }
    }
}
