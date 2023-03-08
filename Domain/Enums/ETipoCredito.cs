using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ETipoCredito
    {
        [Description("Crédito Direto")]
        CREDITO_DIRETO,

        [Description("Crédito Consignado")]
        CREDITO_CONSIGNADO,

        [Description("Crédito Pessoa Jurídica")]
        CREDITO_PESSOA_JURIDICA,

        [Description("Crédito Pessoa Física")]
        CREDITO_PESSOA_FISICA,

        [Description("Crédito Imobiliário")]
        CREDITO_IMOBILIARIO
    }
}
