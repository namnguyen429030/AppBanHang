using AppBanHang.Exceptions;
using AppBanHang.Services.Interfaces;
using AppBanHang.ViewModels.Base;
using MsBox.Avalonia;
using ReactiveUI;
using System;
using System.Reactive;

using System.Threading.Tasks;


namespace AppBanHang.ViewModels.Views
{
    public partial class LoginViewModel : RoutableViewModelBase
    {
        private readonly IUserService _userService;
        private readonly IScreen _hostScreen;
        private string _enteredUsername = string.Empty;
        private string _enteredPassword = string.Empty;
        private bool _isUsernameEmpty = true;
        private bool _isPasswordEmpty = true;
        private bool _canLogin;
        public bool CanLogin
        {
            get => _canLogin;
            set => this.RaiseAndSetIfChanged(ref _canLogin, value);
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
        public ReactiveCommand<Unit, Unit> LoginCommand { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> SwitchToRegistrationViewCommand { get; }
        public LoginViewModel(IScreen hostScreen, IUserService userService) : base(hostScreen)
        {
            _userService = userService;
            _hostScreen = hostScreen;
            LoginCommand = ReactiveCommand.CreateFromTask(Login);
            SwitchToRegistrationViewCommand = ReactiveCommand.CreateFromObservable(() => _hostScreen.Router.Navigate.Execute(new RegistrationViewModel(hostScreen, userService, this)));
            this.WhenAnyValue(x => x.EnteredUsername).Subscribe(x => IsUsernameEmpty = string.IsNullOrWhiteSpace(x));
            this.WhenAnyValue(x => x.EnteredPassword).Subscribe(x => IsPasswordEmpty = string.IsNullOrWhiteSpace(x));
            this.WhenAnyValue(x => x.IsUsernameEmpty, x => x.IsPasswordEmpty)
                .Subscribe((canLogin) =>
                {
                    CanLogin = !canLogin.Item1 && !canLogin.Item2;
                });
        }
        private async Task Login()
        {
            try
            {
                await _userService.LoginAsync(EnteredUsername.Trim(), EnteredPassword);
            }
            catch (InvalidLoginException)
            {
                await MessageBoxManager.GetMessageBoxStandard("Failed", "Sai thong tin dang nhap", MsBox.Avalonia.Enums.ButtonEnum.Ok).ShowAsync();
            }
        }
    }
}
