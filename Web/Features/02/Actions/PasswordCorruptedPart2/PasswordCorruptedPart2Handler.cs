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
        public class PasswordCorruptedPart2Handler : BaseHandler<PasswordCorruptedPart2Action>
        {
            public PasswordCorruptedPart2Handler(IStore store) : base(store)
            {
            }

            public override async Task<Unit> Handle(PasswordCorruptedPart2Action action, CancellationToken cancellationToken)
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

                    var positionOne = int.Parse(minMax.First());
                    var positionTwo = int.Parse(minMax.Last());

                    var subject = lineParts[1][0];

                    var password = lineParts.Last();

                    var positionOneMatch = positionOne - 1 <= password.Length && subject == password[positionOne - 1];
                    var positionTwoMatch = positionTwo - 1 <= password.Length && subject == password[positionTwo - 1];

                    if ((positionOneMatch || positionTwoMatch) && (positionOneMatch && positionTwoMatch) == false) numberOfValidPasswords++;
                }

                return numberOfValidPasswords;
            }
        }
    }
}