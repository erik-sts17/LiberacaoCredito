using Domain.ViewModels.Request;
using Domain.ViewModels.Response;

namespace Domain.Interfaces
{
    public interface ILiberacaoCreditoService 
    {
        LiberacaoCreditoResponseViewModel LiberarCredito(LiberacaoCreditoRequestViewModel liberacaoCreditoRequestViewModel);
    }
}
