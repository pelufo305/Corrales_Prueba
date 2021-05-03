using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Siigo.Corrales.Domain.AggregateModel.ExampleAggregate;
using Siigo.Corrales.Domain.AggregatesModel.AnimalAggregate;

namespace Siigo.Animales.Api.Application.Commands
{
    /// <summary>
    /// Handler which processes the command when
    /// customer executes cancel order from app
    /// </summary>
    public class AnimalCommandHandler : IRequestHandler<AnimalCommand, string>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ICorralFinder _corralFinder;
        private readonly IAnimalFinder _animalFinder;

        // Add any injected repository/helper/util 
        // or any class needed to handle the command
        public AnimalCommandHandler(IAnimalRepository animalRepository, ICorralFinder corralFinder, IAnimalFinder animalFinder)
        {
            _animalRepository = animalRepository;
            _corralFinder = corralFinder;
            _animalFinder = animalFinder;
        }

        public async Task<string> Handle(AnimalCommand request, CancellationToken cancellationToken)
        {

            var typecorral = await  _corralFinder.GetByID(request.CorralCode);
            var countanimal = await _animalFinder.GetCountAnimalByCorral(request.CorralCode);

            if (typecorral.limit <= countanimal)
            {
                return $"Corral ya se encuentra lleno";
            }

            if (request.TypeCode != typecorral.typecode)
            {
                return $"No se puede ingresar este tipo de animal al corral" ;
            }

            Animal animal = new Animal();
            animal.id  = request.Id;
            animal.name = request.Name;
            animal.edad = request.Edad;
            animal.typecode = request.TypeCode;
            animal.corralcode = request.CorralCode;
            animal.isdangerous = request.IsDangerous;
            var example = await _animalRepository.Create(animal);
            if (example)
            {
                return $"Se registro correctamente el animal";
            }
            else
            {
                return $" NO Se registro correctamente el animal";
            }
        }
    }
}
