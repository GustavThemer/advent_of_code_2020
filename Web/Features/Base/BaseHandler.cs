using BlazorState;

namespace Web.Features.Base
{
    internal abstract class BaseHandler<TAction> : ActionHandler<TAction>
        where TAction : IAction
    {
        protected BaseHandler(IStore store) : base(store)
        {
        }

        protected ApplicationState State => Store.GetState<ApplicationState>();
    }
}