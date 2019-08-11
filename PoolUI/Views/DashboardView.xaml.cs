using System.Windows;

namespace PoolUI.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class DashboardView : Window
    {
        public DashboardView()
        {
            InitializeComponent();
            Left = System.Windows.SystemParameters.WorkArea.Width - Width;
            Top = System.Windows.SystemParameters.WorkArea.Height - Height;
        }

       
    }
}
