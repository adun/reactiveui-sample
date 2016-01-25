using System;
using ReactiveUI;
using Splat;

namespace ReactUiSample.ViewModels
{
    public interface IMainViewModel : IRoutableViewModel
    {
        IReactiveCommand HelloWorld { get; }
    }

    public class MainViewModel : ReactiveObject, IMainViewModel
    {
        public string UrlPathSegment => "main";

        string _welcome;
        public string Welcome
        {
            get { return _welcome; }
            set { this.RaiseAndSetIfChanged(ref _welcome, value); }
        }

        public IScreen HostScreen { get; protected set; }

        public ReactiveCommand<object> HelloWorld { get; protected set; }
        IReactiveCommand IMainViewModel.HelloWorld => HelloWorld;

        readonly ReactiveList<object> _tabs = new ReactiveList<object>();
        public IReadOnlyReactiveList<object> Tabs
        {
            get { return _tabs; }
        }

        public MainViewModel(IScreen screen)
        {
            HostScreen = screen;

            Welcome = "Welcome";
            //this.WhenAnyValue(x => x.Welcome);

            HelloWorld = ReactiveCommand.Create();
            HelloWorld.Subscribe(param => UserError.Throw(new UserError("It works!!!")));

            LoadTabs();
        }

        private void LoadTabs()
        {
            var tabs = Locator.Current.GetServices<ITabViewModel>();

            _tabs.AddRange(tabs);
        }
    }
}