using BaseProject.InterFaces;
using BaseProject.Services;
using BaseProject.Services.Contracts;
using BaseProject.Views;
using System;

namespace BaseProject.ViewModels
{
    public class MainWindowViewModel : BaseViewModel, IWpfOnInit
    {
        private readonly INavigationService _navigationService;

        public MainWindowViewModel()
        {
            _navigationService = EngineContext.Resolve<INavigationService>();
            Navigate = new RelayCommand<string>(OnNavigate, OnCanNavigate);
            OnInit();
        }

        public void OnInit()
        {
            _navigationService.WhenViewChanges.Subscribe(OnNavigated);
        }

        public RelayCommand<string> Navigate { get; protected set; }



        protected virtual void OnNavigated(INavigationView view)
        {
            NavigatedView = view;
            Navigate.RaiseCanExecuteChanged();
        }

        private INavigationView _navigatedView;

        public INavigationView NavigatedView
        {
            get => _navigatedView;
            set => SetProperty(ref _navigatedView, value);
        }

        protected virtual void OnNavigate(string viewName)
        {
            _navigationService.Navigate(viewName);

        }

        protected virtual bool OnCanNavigate(string viewName)
        {
            return _navigationService.CurrentView == null || _navigationService.CurrentView.Name != viewName;
        }

        public void OnLoad()
        {
            _navigationService.Navigate(nameof(HomeView));
        }
    }
}
