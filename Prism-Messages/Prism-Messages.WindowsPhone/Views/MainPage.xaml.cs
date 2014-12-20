using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.StoreApps;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Prism_Messages.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : VisualStateAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }
    }
}
