using BlazorState;

namespace Web.Features
{
    internal partial class ApplicationState : State<ApplicationState>
    {
        public int DayOneResult { get; private set; }
        public int DayTwoResult { get; private set; }
        public override void Initialize()
        {
            DayOneResult = 0;
            DayTwoResult = 0;
        }
    }
}