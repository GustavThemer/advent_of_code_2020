using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using Web.Features._01;
using Web.Features.Base;

// ReSharper disable once CheckNamespace
namespace Web.Features
{
    internal partial class ApplicationState
    {
        public class SumExpensesPart1Handler : BaseHandler<SumExpensesPart1Action>
        {
            public SumExpensesPart1Handler(IStore store) : base(store)
            {
            }

            public override async Task<Unit> Handle(SumExpensesPart1Action action, CancellationToken cancellationToken)
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
                        if (numbers[i] + numbers[j] == 2020) return numbers[i] * numbers[j];
                    }
                }

                return 0;
            }
        }
    }
}