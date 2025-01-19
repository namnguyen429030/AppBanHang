using AppBanHang.Exceptions;
using AppBanHang.Models;
using AppBanHang.Services.Interfaces;
using AppBanHang.ViewModels.Base;
using BCrypt.Net;
using MsBox.Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.ViewModels.Views
{
    public class RegistrationViewModel : RoutableViewModelBase
    {
        private readonly IUserService _userService;
        private readonly IScreen _hostScreen;
        private readonly LoginViewModel _loginViewModel;
        private string _enteredUsername = string.Empty;
        private string _enteredPassword = string.Empty;
        private string _enteredAlias = string.Empty;
        private string _enteredClientKey = string.Empty;
        private string _enteredApiKey = string.Empty;
        private string _enteredCheckSumKey = string.Empty;
        private bool _isUsernameEmpty = true;
        private bool _isPasswordEmpty = true;
        private bool _isAliasEmpty = true;
        private bool _isClientKeyEmpty = true;
        private bool _isApiKeyEmpty = true;
        private bool _isCheckSumKeyEmpty = true;
        private bool _isRegisterable;
        public bool IsRegisterable
        {
            get => _isRegisterable;
            set => this.RaiseAndSetIfChanged(ref _isRegisterable, value);
        }
        public bool IsUsernameEmpty
        {
            get => _isUsernameEmpty;
            set => this.RaiseAndSetIfChanged(ref _isUsernameEmpty, value);
        }
        public bool IsPasswordEmpty
        {
            get => _isPasswordEmpty;
            set => this.RaiseAndSetIfChanged(ref _isPasswordEmpty, value);
        }
        public bool IsAliasEmpty
        {
            get => _isAliasEmpty;
            set => this.RaiseAndSetIfChanged(ref _isAliasEmpty, value);
        }
        public bool IsClientKeyEmpty
        {
            get => _isClientKeyEmpty;
            set => this.RaiseAndSetIfChanged(ref _isClientKeyEmpty, value);
        }
        public bool IsApiKeyEmpty
        {
            get => _isApiKeyEmpty;
            set => this.RaiseAndSetIfChanged(ref _isApiKeyEmpty, value);
        }
        public bool IsCheckSumKeyEmpty
        {
            get => _isCheckSumKeyEmpty;
            set => this.RaiseAndSetIfChanged(ref _isCheckSumKeyEmpty, value);
        }
        public string EnteredUsername
        {
            get => _enteredUsername;
            set => this.RaiseAndSetIfChanged(ref _enteredUsername, value);
        }
        public string EnteredPassword
        {
            get => _enteredPassword;
            set => this.RaiseAndSetIfChanged(ref _enteredPassword, value);
        }
        public string EnteredAlias
        {
            get => _enteredAlias;
            set => this.RaiseAndSetIfChanged(ref _enteredAlias, value);
        }
        public string EnteredClientKey
        {
            get => _enteredClientKey;
            set => this.RaiseAndSetIfChanged(ref _enteredClientKey, value);
        }
        public string EnteredApiKey
        {
            get => _enteredApiKey;
            set => this.RaiseAndSetIfChanged(ref _enteredApiKey, value);
        }
        public string EnteredCheckSumKey
        {
            get => _enteredCheckSumKey;
            set => this.RaiseAndSetIfChanged(ref _enteredCheckSumKey, value);
        }
        public ReactiveCommand<Unit, IRoutableViewModel> SwitchToLoginViewCommand { get; }
        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }
        public RegistrationViewModel(IScreen hostScreen, IUserService userService, LoginViewModel loginViewModel) : base(hostScreen)
        {
            _hostScreen = hostScreen;
            _userService = userService;
            _loginViewModel = loginViewModel;
            SwitchToLoginViewCommand = ReactiveCommand.CreateFromObservable(() => _hostScreen.Router.Navigate.Execute(_loginViewModel));
            RegisterCommand = ReactiveCommand.CreateFromTask(Register);

            this.WhenAnyValue(x => x.EnteredUsername).Subscribe(x => IsUsernameEmpty = string.IsNullOrWhiteSpace(x));
            this.WhenAnyValue(x => x.EnteredPassword).Subscribe(x => IsPasswordEmpty = string.IsNullOrWhiteSpace(x));
            this.WhenAnyValue(x => x.EnteredAlias).Subscribe(x => IsAliasEmpty = string.IsNullOrWhiteSpace(x));
            this.WhenAnyValue(x => x.EnteredClientKey).Subscribe(x => IsClientKeyEmpty = string.IsNullOrWhiteSpace(x));
            this.WhenAnyValue(x => x.EnteredApiKey).Subscribe(x => IsApiKeyEmpty = string.IsNullOrWhiteSpace(x));
            this.WhenAnyValue(x => x.EnteredCheckSumKey).Subscribe(x => IsCheckSumKeyEmpty = string.IsNullOrWhiteSpace(x));
            this.WhenAnyValue(x => x.IsUsernameEmpty,
                            x => x.IsPasswordEmpty,
                            x => x.IsClientKeyEmpty,
                            x => x.IsApiKeyEmpty,
                            x => x.IsCheckSumKeyEmpty)
                            .Select(x => !x.Item1 && !x.Item2 && !x.Item3 && !x.Item4 && !x.Item5)
                            .Subscribe(isValid => IsRegisterable = isValid);
        }
        private async Task Register()
        {
            try
            {
                User user = new();
                user.UserName = EnteredUsername;
                user.Password = BCrypt.Net.BCrypt.HashPassword(EnteredPassword);
                user.Alias = string.IsNullOrWhiteSpace(EnteredAlias) ? EnteredUsername : EnteredAlias;
                user.ClientKey = EnteredClientKey;
                user.ApiKey = EnteredApiKey;
                user.ChecksumKey = EnteredCheckSumKey;
                await _userService.AddUserAsync(user);
                await _hostScreen.Router.Navigate.Execute(_loginViewModel);
            }
            catch (InvalidRegistrationException)
            {
                await MessageBoxManager.GetMessageBoxStandard("Failed", "Sai thong tin dang ky", MsBox.Avalonia.Enums.ButtonEnum.Ok).ShowAsync();
            }
        }
    }
}
