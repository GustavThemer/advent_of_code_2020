using System.Threading.Tasks;
using BlazorState.Pipeline.ReduxDevTools;
using MediatR;

namespace Web.Features.Base.Components
{
    public abstract class BaseComponent : BlazorStateDevToolsComponent
    {
        internal ApplicationState State => GetState<ApplicationState>();

        protected async Task Send(IRequest request) => await Mediator.Send(request).ConfigureAwait(false);
    }
}