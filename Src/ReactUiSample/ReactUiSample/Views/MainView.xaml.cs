using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ReactiveUI;
using ReactUiSample.ViewModels;

namespace ReactUiSample.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, IViewFor<IMainViewModel>
    {
        public MainView()
        {
            InitializeComponent();

            this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext);

            UserError.RegisterHandler(async error =>
            {
                RxApp.MainThreadScheduler.Schedule<UserError>(error,
                (scheduler, userError) =>
                {
                    // NOTE: this code really shouldn't throw away the MessageBoxResult
                    var result = MessageBox.Show(userError.ErrorMessage);
                    return Disposable.Empty;
                });

                return await Task.Run<RecoveryOptionResult>(() => RecoveryOptionResult.CancelOperation);
            });
        }

        public IMainViewModel ViewModel
        {
            get { return (IMainViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(IMainViewModel), typeof(MainView), new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (IMainViewModel)value; }
        }
    }
}
