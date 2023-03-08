using Domain.Enums;
using Domain.Interfaces;
using Domain.ViewModels.Request;
using Domain.ViewModels.Response;

namespace Services
{
    public class LiberacaoCreditoService : ILiberacaoCreditoService
    {
        public LiberacaoCreditoResponseViewModel LiberarCredito(LiberacaoCreditoRequestViewModel liberacaoCreditoRequestViewModel)
        {
            var retorno = ValidarLiberacaoCredito(liberacaoCreditoRequestViewModel);
            switch (liberacaoCreditoRequestViewModel.TipoCredito)
            {
                case ETipoCredito.CREDITO_DIRETO:
                    return CalcularJuros(0.02m, liberacaoCreditoRequestViewModel.ValorCredito, liberacaoCreditoRequestViewModel.QuantidadeParcelas, retorno);

                case ETipoCredito.CREDITO_CONSIGNADO:
                    return CalcularJuros(0.01m, liberacaoCreditoRequestViewModel.ValorCredito, liberacaoCreditoRequestViewModel.QuantidadeParcelas, retorno);

                case ETipoCredito.CREDITO_PESSOA_JURIDICA:
                    return CalcularJuros(0.05m, liberacaoCreditoRequestViewModel.ValorCredito, liberacaoCreditoRequestViewModel.QuantidadeParcelas, retorno);

                case ETipoCredito.CREDITO_PESSOA_FISICA:
                    return CalcularJuros(0.03m, liberacaoCreditoRequestViewModel.ValorCredito, liberacaoCreditoRequestViewModel.QuantidadeParcelas, retorno);

                case ETipoCredito.CREDITO_IMOBILIARIO:
                    return CalcularJuros(0.09m, liberacaoCreditoRequestViewModel.ValorCredito, liberacaoCreditoRequestViewModel.QuantidadeParcelas, retorno);

                default:
                    throw new Exception("Tipo de Crédito inválido");
            }
        }

        private string? ValidarLiberacaoCredito(LiberacaoCreditoRequestViewModel liberacaoCreditoRequestViewModel)
        {
            if (liberacaoCreditoRequestViewModel.ValorCredito > 1000000m)
                return "O valor de crédito máximo liberado é de R$ 1.000.000,00";

            if (liberacaoCreditoRequestViewModel.QuantidadeParcelas < 5 || liberacaoCreditoRequestViewModel.QuantidadeParcelas > 72)
                return "A quantidade de parcelas deve ser entre 5 e 72";

            if (liberacaoCreditoRequestViewModel.TipoCredito == ETipoCredito.CREDITO_PESSOA_JURIDICA && liberacaoCreditoRequestViewModel.ValorCredito < 15000m)
                return $"Para o crédito pessoa jurídica o valor mínimo é de R$ 15.000,00";

            var dataAtual = DateTime.Now.Date;
            if (dataAtual.AddDays(15) > liberacaoCreditoRequestViewModel.DataPrimeiroVencimento.Date || dataAtual.AddDays(40) < liberacaoCreditoRequestViewModel.DataPrimeiroVencimento.Date)
                return $"A data do primeiro vencimento deve estar entre 15 e 40 dias, a partir da data de hoje - {dataAtual.ToShortDateString()}";

            return null;
        }

        private LiberacaoCreditoResponseViewModel CalcularJuros(decimal taxaJuros, decimal valorCredito, int quantidadeParcelas, string? mensagemReprovacao)
        {
            var juros = valorCredito * taxaJuros;
            return new LiberacaoCreditoResponseViewModel()
            {
                StatusCredito = string.IsNullOrEmpty(mensagemReprovacao) ? EStatusCredito.APROVADO : EStatusCredito.RECUSADO,
                ValorTotal = valorCredito + juros,
                ValorJuros = juros,
                MensagemReprovacao = mensagemReprovacao
            };
        }
    }
}
