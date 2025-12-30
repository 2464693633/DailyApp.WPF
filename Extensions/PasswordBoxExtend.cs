using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DailyApp.WPF.Extensions
{
    /// <summary>
    /// PasswordBox扩展属性
    /// </summary>
    public class PasswordBoxExtend
    {

        public static string GetPwd(DependencyObject obj)
        {
            return (string)obj.GetValue(PwdProperty);
        }

        public static void SetPwd(DependencyObject obj, string value)
        {
            obj.SetValue(PwdProperty, value);
        }

        // Using a DependencyProperty as the backing store for Pwd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PwdProperty =
            DependencyProperty.RegisterAttached("Pwd", typeof(string), typeof(PasswordBoxExtend), new PropertyMetadata("",OnPwdChanged));

        /// <summary>
        /// 自定义属性发生变化 改变Password属性值
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPwdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pwdBox = d as PasswordBox;
            string newPwd = (string)e.NewValue;//新的值
            if (pwdBox != null&& pwdBox.Password != newPwd)
            {
                pwdBox.Password = newPwd;
            }
        }
    }

    /// <summary>
    /// Password行为 Password变化，自定义附加属性跟着变化
    /// </summary>
    public class PasswordBoxBehavior: Behavior<PasswordBox>
    {
        /// <summary>
        /// 附加 注入事件
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PasswordChanged += OnPasswordChanged;
        }
        /// <summary>
        /// Password变化，自定义附加属性跟着变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            string password = PasswordBoxExtend.GetPwd(passwordBox);
            if (passwordBox != null && passwordBox.Password != password)
            { 
                PasswordBoxExtend.SetPwd(passwordBox, passwordBox.Password);
            }
        }

        /// <summary>
        /// 移除 注销事件
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= OnPasswordChanged;
        }

    }
}
