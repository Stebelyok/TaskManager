using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace TaskManager.Utils
{
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxHelper),
                new FrameworkPropertyMetadata(string.Empty, OnBoundPasswordChanged));

        public static string GetBoundPassword(DependencyObject obj) =>
            (string)obj.GetValue(BoundPasswordProperty);

        public static void SetBoundPassword(DependencyObject obj, string value) =>
            obj.SetValue(BoundPasswordProperty, value);

        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox && e.NewValue is string newPassword)
            {
                if (passwordBox.Password != newPassword)
                    passwordBox.Password = newPassword;
            }
        }

        public static readonly DependencyProperty BindPasswordProperty =
            DependencyProperty.RegisterAttached("BindPassword", typeof(bool), typeof(PasswordBoxHelper),
                new PropertyMetadata(false, OnBindPasswordChanged));

        public static bool GetBindPassword(DependencyObject obj) =>
            (bool)obj.GetValue(BindPasswordProperty);

        public static void SetBindPassword(DependencyObject obj, bool value) =>
            obj.SetValue(BindPasswordProperty, value);

        private static void OnBindPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                if ((bool)e.NewValue)
                {
                    passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
                }
                else
                {
                    passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
                }
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                SetBoundPassword(passwordBox, passwordBox.Password);
            }
        }
    }
}
