using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BaseProject.InterFaces
{
    public interface INavigation
    {
        string RouteName { get; }
    }
    public interface IViewNavigation : INavigation, IInterface
    {
        PackIconKind Icon { get; }
        RelayCommand OnNavigation { get; }
        void Navigate();
        bool CanNavigate();

    }
}
