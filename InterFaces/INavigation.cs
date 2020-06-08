using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject.InterFaces
{
    public interface INavigation
    {
        string RouteName { get; }
    }
    public interface IViewNavigation : INavigation
    {
        PackIconKind Icon { get; }
    }
}
