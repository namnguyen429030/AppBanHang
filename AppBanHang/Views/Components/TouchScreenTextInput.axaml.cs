using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AppBanHang.Views.Components
{

    public partial class TouchScreenTextInput : TouchScreenInput
    {
        public TouchScreenTextInput()
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