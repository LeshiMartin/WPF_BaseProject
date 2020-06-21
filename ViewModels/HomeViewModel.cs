using BaseProject.Helpers;
using BaseProject.InterFaces;
using BaseProject.Services;
using BaseProject.Services.Contracts;
using MaterialDesignThemes.Wpf;

namespace BaseProject.ViewModels
{
    public class HomeViewModel : BaseViewModel, IViewNavigation
    {

        public HomeViewModel()
        {
            _navigationService = EngineContext.Resolve<INavigationService>();
            OnNavigation = new RelayCommand(Navigate, CanNavigate);
        }
        public string RouteName => "Home View";
        public PackIconKind Icon => PackIconKind.Home;

        private readonly INavigationService _navigationService;

        public RelayCommand OnNavigation { get; }


        public virtual void Navigate()
        {
            _navigationService.Navigate(nameof(HomeViewModel).ToViewName());
            OnNavigation.RaiseCanExecuteChanged();
        }
        public virtual bool CanNavigate()
        {
            return _navigationService.CurrentView.Name != (nameof(HomeViewModel).ToViewName());
        }
    }
}
