using System.Windows;
using System.Windows.Controls;
using ReactiveUI;
using ReactUiSample.ViewModels;

namespace ReactUiSample.Views
{
    /// <summary>
    /// Interaction logic for Tab1View.xaml
    /// </summary>
    public partial class Tab1View : UserControl, IViewFor<ITab1ViewModel>
    {
        public Tab1View()
        {
            InitializeComponent();
            this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext);
        }

        public ITab1ViewModel ViewModel
        {
            get { return (ITab1ViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ITab1ViewModel), typeof(Tab1View), new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ITab1ViewModel)value; }
        }
    }
}
