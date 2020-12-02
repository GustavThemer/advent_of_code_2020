using BlazorState;
using Microsoft.AspNetCore.Components.Forms;

// ReSharper disable once CheckNamespace
namespace Web.Features
{
    internal partial class ApplicationState
    {
        public class SumExpensesPart1Action : IAction
        {
            public IBrowserFile InputFile { get; }

            public SumExpensesPart1Action(IBrowserFile inputFile)
            {
                InputFile = inputFile;
            }
        }
    }
}