using FluentValidation;
using MediatR;

namespace Siigo.Animales.Api.Application.Commands
{
    /// <summary>
    /// A command has all the data needed to service a request
    /// </summary>
    public class AnimalCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Edad { get; set; }
        public int TypeCode { get; set; }
        public int CorralCode { get; set; }
        public bool IsDangerous { get; set; }

        protected AnimalCommand()
        {
        }

        public AnimalCommand(int id, string name, int edad, int typecode, int corralcode, bool isdangerous)
        {
            Id = id;
            Name = name;
            Edad = edad;
            TypeCode = typecode;
            CorralCode = corralcode;
            IsDangerous = isdangerous;
        }


        public class ExampleCommandValidator : AbstractValidator<AnimalCommand>
        {
            public ExampleCommandValidator()
            {
                RuleFor(m => m.TypeCode).NotNull()
                    .WithMessage("typecode  not null");
                RuleFor(m => m.Edad).NotNull()
                   .WithMessage("edad  not null");
                RuleFor(m => m.CorralCode).NotNull()
                  .WithMessage("corralcode  not null");
            }
        }
    }
}
