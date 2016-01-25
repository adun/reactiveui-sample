using System;
using ReactiveUI;

namespace ReactUiSample.ViewModels
{
    public interface ITab1ViewModel : IRoutableViewModel, ITabViewModel
    {
        IReactiveCommand HelloWorld { get; }
    }

    public class Tab1ViewModel : ReactiveObject, ITab1ViewModel
    {
        public string UrlPathSegment => "tab1";

        public IScreen HostScreen { get; protected set; }
        public ReactiveCommand<object> HelloWorld { get; protected set; }

        IReactiveCommand ITab1ViewModel.HelloWorld => HelloWorld;

        public Tab1ViewModel(IScreen screen)
        {
            HostScreen = screen;

            HelloWorld = ReactiveCommand.Create();
            HelloWorld.Subscribe(param => UserError.Throw(new UserError("It works!!!")));
        }
    }
}