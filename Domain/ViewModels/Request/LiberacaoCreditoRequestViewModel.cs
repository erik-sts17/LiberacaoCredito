using Domain.Enums;

namespace Domain.ViewModels.Request
{
    public class LiberacaoCreditoRequestViewModel
    {
        public decimal ValorCredito { get; set; }
        public ETipoCredito TipoCredito { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
    }
}
