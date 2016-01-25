using System;
using System.Windows;
using MahApps.Metro;
using ReactiveUI;
using ReactUiSample.Views;
using Splat;

namespace ReactUiSample.ViewModels
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public RoutingState Router { get; private set; }

        public AppBootstrapper(IMutableDependencyResolver dependencyResolver = null, RoutingState testRouter = null)
        {
            Router = testRouter ?? new RoutingState();
            dependencyResolver = dependencyResolver ?? Locator.CurrentMutable;

            RegisterParts(dependencyResolver);

            LogHost.Default.Level = LogLevel.Debug;
            LoadCustomTheme();

            Router.Navigate.Execute(new MainViewModel(this));
        }

        private void RegisterParts(IMutableDependencyResolver dependencyResolver)
        {
            dependencyResolver.RegisterConstant(this, typeof(IScreen));

            dependencyResolver.Register(() => new MainView(), typeof(IViewFor<MainViewModel>));
            dependencyResolver.Register(() => new Tab1View(), typeof(IViewFor<Tab1ViewModel>));
            dependencyResolver.Register(() => new Tab2View(), typeof(IViewFor<Tab2ViewModel>));
            dependencyResolver.Register(() => new Tab1ViewModel(this), typeof(ITabViewModel));
            dependencyResolver.Register(() => new Tab2ViewModel(this), typeof(ITabViewModel));
        }

        private void LoadCustomTheme()
        {
            ThemeManager.AddAccent("AppAccent", new Uri("pack://application:,,,/ReactUiSample;component/ResourcesDictionaries/Brushes/AppAccent.xaml"));
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("AppAccent"), theme.Item1);
        }
    }
}