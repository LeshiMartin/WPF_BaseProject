using BaseProject.InterFaces;
using System.Windows.Controls;

namespace BaseProject.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl, INavigationView
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}
