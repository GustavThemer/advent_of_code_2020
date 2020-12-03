using BlazorState;
using Microsoft.AspNetCore.Components.Forms;

// ReSharper disable once CheckNamespace
namespace Web.Features
{
    internal partial class ApplicationState
    {
        public class PasswordCorruptedPart1Action : IAction
        {
            public IBrowserFile InputFile { get; }

            public PasswordCorruptedPart1Action(IBrowserFile inputFile)
            {
                InputFile = inputFile;
            }
        }
    }
}