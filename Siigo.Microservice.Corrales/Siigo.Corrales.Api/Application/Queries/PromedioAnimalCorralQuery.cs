using MediatR;
using Siigo.Corrales.Api.Application.Model;

namespace Siigo.Corrales.Api.Application.Queries
{
    /// <summary>
    /// We handle the query objects like the command and command handlers
    /// The Query DTO includes all the data needed to handle the request
    /// </summary>
    public class PromedioAnimalCorralQuery : IRequest<string> // replace object with your class
    {
        public int Id { get; }

        public PromedioAnimalCorralQuery(int id)
        {
            Id = id;
        }
    }
}
