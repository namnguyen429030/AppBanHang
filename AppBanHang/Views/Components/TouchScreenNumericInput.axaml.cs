using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace AppBanHang.Views.Components
{
    public partial class TouchScreenNumericInput : TouchScreenInput
    {
        public TouchScreenNumericInput()
        {
            AvaloniaXamlLoader.Load(this);
            KeyboardPopup = this.FindControl<Popup>("keyboardPopup");
        }
        protected override void KeyboardButtonClick(object? sender, RoutedEventArgs args)
        {
            base.KeyboardButtonClick(sender, args);
        }
    }
}