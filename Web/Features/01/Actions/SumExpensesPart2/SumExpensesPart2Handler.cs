using System.Collections.Generic;
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
        public class SumExpensesPart2Handler : BaseHandler<SumExpensesPart2Action>
        {
            public SumExpensesPart2Handler(IStore store) : base(store)
            {
            }

            public override async Task<Unit> Handle(SumExpensesPart2Action action, CancellationToken cancellationToken)
            {
                var numbers = await action.InputFile.GetNumbers();
                State.DayOneResult = CalculateExpenses(numbers);

                return Unit.Value;
            }

            public int CalculateExpenses(IReadOnlyList<int> numbers)
            {
                for (var i = 0; i < numbers.Count - 1; i++)
                {
                    for (var j = i + 1; j < numbers.Count - 1; j++)
                    {
                        for (var k = 0; k < numbers.Count - 1; k++)
                        {
                            if (numbers[i] + numbers[j] + numbers[k] == 2020) return numbers[i] * numbers[j] * numbers[k];
                        }
                    }
                }

                return 0;
            }
        }
    }
}