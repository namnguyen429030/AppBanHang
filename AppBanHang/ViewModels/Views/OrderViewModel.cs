using AppBanHang.Models;
using AppBanHang.Services.Interfaces;
using AppBanHang.ViewModels.Base;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;

namespace AppBanHang.ViewModels.Views
{
    public class OrderViewModel : RoutableViewModelBase
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        private ObservableCollection<Order> _orders;
        private ObservableCollection<Product> _products;
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set => this.RaiseAndSetIfChanged(ref _orders, value);
        }
        public ObservableCollection<Product> Products
        {
            get => _products;
            set => this.RaiseAndSetIfChanged(ref _products, value);

        }
        public OrderViewModel(IScreen hostScreen, IUserService userService, IOrderService orderService, IProductService productService) : base(hostScreen)
        {
            _userService = userService;
            _orderService = orderService;
            _productService = productService;

            _userService.CurrentUserChanged += OnCurrentUserChanged;
        }
        public void OnCurrentUserChanged(User? user)
        {
            if (user != null)
            {
                Orders = new(_orderService.GetAllOrdersByUserId(user.Id));
                Products = new(_productService.GetAllProductsByUserId(user.Id));
            }
        }
    }
}
