using System.Windows;
using System.Windows.Controls;
using ReactiveUI;
using ReactUiSample.ViewModels;

namespace ReactUiSample.Views
{
    /// <summary>
    /// Interaction logic for Tab2View.xaml
    /// </summary>
    public partial class Tab2View : UserControl, IViewFor<ITab2ViewModel>
    {
        public Tab2View()
        {
            InitializeComponent();
            this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext);
        }

        public ITab2ViewModel ViewModel
        {
            get { return (ITab2ViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ITab2ViewModel), typeof(Tab2View), new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ITab2ViewModel)value; }
        }
    }
}
