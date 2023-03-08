using Domain.Interfaces;
using Domain.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;

namespace LiberacaoCredito.Controllers
{
    public class LiberacaoCreditoController : Controller
    {
        private readonly ILiberacaoCreditoService _liberacaoCreditoService;
        public LiberacaoCreditoController(ILiberacaoCreditoService liberacaoCreditoService)
        {
            _liberacaoCreditoService = liberacaoCreditoService;
        }

        [HttpGet ("[action]")]
        public IActionResult LiberarCredito([FromQuery] LiberacaoCreditoRequestViewModel liberacaoCreditoRequestViewModel)
        {
            var result = _liberacaoCreditoService.LiberarCredito(liberacaoCreditoRequestViewModel);
            return Ok(result);
        }
    }
}
