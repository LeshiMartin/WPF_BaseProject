using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BaseProject.Helpers
{
    public static class PasswordBoxAttach
    {
        public static readonly DependencyProperty BoundPassword =
            DependencyProperty.RegisterAttached("BoundPassword",
                                            typeof(string),
                                                typeof(PasswordBoxAttach),
                                            new PropertyMetadata(string.Empty, OnBoundPasswordChange));

        private static bool _isUpdatind;

        private static void OnBoundPasswordChange(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (_isUpdatind)
                return;


            if (!(dp is PasswordBox pwBox))
                return;
            pwBox.PasswordChanged -= PwBoxOnPasswordChanged;
            pwBox.Password = e.NewValue as string;
            pwBox.PasswordChanged += PwBoxOnPasswordChanged;

        }

        private static void PwBoxOnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!(sender is PasswordBox pwBox))
                return;
            _isUpdatind = true;
            SetBoundPassword(pwBox, pwBox.Password);
            _isUpdatind = false;

        }


        public static string GetBoundPassword(DependencyObject dp)
        {
            return dp.GetValue(BoundPassword) as string;
        }

        public static void SetBoundPassword(DependencyObject dp, string val)
        {
            dp.SetValue(BoundPassword, val);
        }
    }
}
