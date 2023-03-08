using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EStatusCredito
    {
        [Description("Aprovado")]
        APROVADO,


        [Description("Recusado")]
        RECUSADO
    }
}
