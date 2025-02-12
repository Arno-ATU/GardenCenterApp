using GardenApp.ViewModels;


namespace GardenApp.Views
{
    public partial class ToolsPage:ContentPage
    {
        public ToolsPage()
        {
            InitializeComponent();
            BindingContext = new ToolsViewModel();
        }
    }
}
