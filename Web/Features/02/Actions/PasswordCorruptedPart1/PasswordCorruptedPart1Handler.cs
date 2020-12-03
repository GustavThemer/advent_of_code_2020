using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using Web.Features.Base;
using Web.Infrastructure;

// ReSharper disable once CheckNamespace
namespace Web.Features
{
    internal partial class ApplicationState
    {
        public class PasswordCorruptedPart1Handler : BaseHandler<PasswordCorruptedPart1Action>
        {
            public PasswordCorruptedPart1Handler(IStore store) : base(store)
            {
            }

            public override async Task<Unit> Handle(PasswordCorruptedPart1Action action, CancellationToken cancellationToken)
            {
                var lines = await action.InputFile.GetLines();
                State.DayTwoResult = ValidatePasswords(lines);

                return Unit.Value;
            }

            private int ValidatePasswords(List<string> input)
            {
                var numberOfValidPasswords = 0;

                foreach (var line in input)
                {
                    var lineParts = line.Split(' ');
                    var minMax = lineParts[0].Split('-');

                    var minimum = int.Parse(minMax.First());
                    var maximum = int.Parse(minMax.Last());

                    var amountInPassword = 0;
                    var subject = lineParts[1][0];

                    var password = lineParts.Last();

                    foreach (var character in password)
                    {
                        if (character == subject) amountInPassword++;
                    }

                    if (amountInPassword >= minimum && amountInPassword <= maximum) numberOfValidPasswords++;
                }

                return numberOfValidPasswords;
            }
        }
    }
}