using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.Views.Components
{
    public abstract class TouchScreenInput : UserControl
    {
        public Popup? KeyboardPopup { get; protected set; }
        public TextBox? TouchScreenTextBox { get; protected set; }
        protected void ShowKeyboard(object sender, GotFocusEventArgs args)
        {
            var textBox = sender as TextBox;
            Debug.WriteLine(KeyboardPopup);
            if (textBox != null && KeyboardPopup != null)
            {
                KeyboardPopup.IsOpen = true;
            }
        }

        protected void HideKeyboard(object? sender, RoutedEventArgs args)
        {
            if (KeyboardPopup != null && !KeyboardPopup.IsPointerOverPopup)
            {
                KeyboardPopup.IsOpen = false;
            }
        }

        protected virtual void KeyboardButtonClick(object? sender, RoutedEventArgs args)
        {
            if (KeyboardPopup != null)
            {
                KeyboardPopup.Focus();
            }
        }
    }
}
