using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Controls;
using BaseProject.Helpers;
using BaseProject.InterFaces;

namespace BaseProject.ViewModels
{
    public class MainWindowViewModel:BaseViewModel
    {

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNavigation);
        }
        private IDictionary<string, IViewNavigation> Navigators { get; set; }

        private INavigation _currentViewModel;
        public INavigation CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        private List<IViewNavigation> _iViewNavigators;

        public List<IViewNavigation> IViewNavigators
        {
            get => _iViewNavigators;
            set => SetProperty(ref _iViewNavigators, value);
        }

        public RelayCommand<string> NavCommand { get; }



        public void OnNavigation(string type)
        {
            type = type.ToListViewItemName();
            if (Navigators != null && Navigators.ContainsKey(type))
                CurrentViewModel = Navigators[type];
        }

        public void OnLoad()
        {

            IViewNavigators = GetType().GetTypeInfo().Assembly.DefinedTypes
                .Where(x => x.ImplementedInterfaces.Any(type => type == typeof(IViewNavigation)))
                .Where(x => x.Name != "SignInViewModel")
                .Select(x => Activator.CreateInstance(x) as IViewNavigation).ToList();

            Navigators = IViewNavigators.ToDictionary(x => string.Join("_", x.RouteName.Split(' ')), x => x);

            CurrentViewModel = new HomeViewModel();

        }
    }
}
