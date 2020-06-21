using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject.InterFaces
{
    public interface IView : IInterface
    {
        object DataContext { get; set; }
        string Name { get; set; }
    }

    public interface INavigationView : IView
    {

    }
}
