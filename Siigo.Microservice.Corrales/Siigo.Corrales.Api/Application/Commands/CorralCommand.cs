using FluentValidation;
using MediatR;

namespace Siigo.Corrales.Api.Application.Commands
{
    /// <summary>
    /// A command has all the data needed to service a request
    /// </summary>
    public class CorralCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Limit { get; set; }
        public int TypeCode { get; set; }

        protected CorralCommand()
        {
        }

        public CorralCommand(int id, string name, int limit, int typecode)
        {
            Id = id;
            Name = name;
            Limit = limit;
            TypeCode = typecode;
        }


        public class ExampleCommandValidator : AbstractValidator<CorralCommand>
        {
            public ExampleCommandValidator()
            {
                RuleFor(m => m.TypeCode).NotNull()
                    .WithMessage("typecode  not null");
                RuleFor(m => m.Limit).NotNull()
                   .WithMessage("limit  not null");
            }
        }
    }
}
