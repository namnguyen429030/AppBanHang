using AppBanHang.Models;
using AppBanHang.ViewModels.Windows;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using MsBox.Avalonia;
using ReactiveUI;
using System;
using System.Reactive.Disposables;

namespace AppBanHang.Views.Windows
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ViewModel = serviceProvider.GetService<MainWindowViewModel>();
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Router, x => x.RoutedViewHost.Router)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.GoToHomeView, x => x.homeBtn)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.GoToStockView, x => x.stockBtn)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.GoToPaymentView, x => x.paymentBtn)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.GoToHistoryView, x => x.historyBtn)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.GoToOrderView, x => x.orderBtn)
                    .DisposeWith(disposables);
            });
        }
        private void LoseAllFocus(object? sender, PointerPressedEventArgs args)
        {
            var mainGrid = sender as Grid;
            if (mainGrid != null)
            {
                mainGrid.Focus();
            }
        }
        public void QuitCommand(object? sender, RoutedEventArgs args)
        {
            Close();
        }
    }
}