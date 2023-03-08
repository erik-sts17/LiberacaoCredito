using Domain.Enums;
using System.Text.Json.Serialization;

namespace Domain.ViewModels.Response
{
    public class LiberacaoCreditoResponseViewModel
    {
        public EStatusCredito StatusCredito { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorJuros { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MensagemReprovacao { get; set; }
    }
}
