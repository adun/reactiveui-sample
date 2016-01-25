using System;
using ReactiveUI;

namespace ReactUiSample.ViewModels
{
    public interface ITab2ViewModel : IRoutableViewModel, ITabViewModel
    {
        IReactiveCommand HelloWorld { get; }
    }

    public class Tab2ViewModel : ReactiveObject, ITab2ViewModel
    {
        public string UrlPathSegment => "tab2";

        public IScreen HostScreen { get; protected set; }

        public ReactiveCommand<object> HelloWorld { get; protected set; }
        IReactiveCommand ITab2ViewModel.HelloWorld => HelloWorld;

        public Tab2ViewModel(IScreen screen)
        {
            HostScreen = screen;

            HelloWorld = ReactiveCommand.Create();
            HelloWorld.Subscribe(param => UserError.Throw(new UserError("It works!!!")));
        }
    }
}