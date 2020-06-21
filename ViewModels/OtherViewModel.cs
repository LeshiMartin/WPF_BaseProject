using BaseProject.Helpers;
using BaseProject.InterFaces;
using BaseProject.Services;
using BaseProject.Services.Contracts;
using BaseProject.Views;
using MaterialDesignThemes.Wpf;

namespace BaseProject.ViewModels
{
    public class OtherViewModel : BaseViewModel, IViewNavigation
    {
        private readonly INavigationService _navigationService;

        public OtherViewModel()
        {
            _navigationService = EngineContext.Resolve<INavigationService>();
            OnNavigation = new RelayCommand(Navigate, CanNavigate);
        }
        public string RouteName => "Other View";
        public PackIconKind Icon => PackIconKind.AbTesting;

        public RelayCommand OnNavigation { get; }

        public bool CanNavigate()
        {
            return _navigationService.CurrentView.Name != nameof(OtherView).ToViewName();
        }

        public void Navigate()
        {
            _navigationService.Navigate(nameof(OtherViewModel).ToViewName());
            OnNavigation.RaiseCanExecuteChanged();
        }
    }
}
