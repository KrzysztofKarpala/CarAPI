using MediatR;

namespace CarAPI.Application.Queries
{
    public class CheckCarResponseQuery : IRequest<bool>
    {
        public int CarId { get; set; }
    }
}
