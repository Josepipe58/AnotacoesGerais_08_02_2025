using Microsoft.Extensions.DependencyInjection;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Windows;

namespace NavigationMVVM
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<CategoriaStore>();
            services.AddSingleton<PeopleStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();

            services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));
            services.AddSingleton<CloseModalNavigationService>();

            services.AddTransient<HomeViewModel>(s => new HomeViewModel(CreateLoginNavigationService(s)));
            services.AddTransient<CategoriaViewModel>(s => new CategoriaViewModel(
                s.GetRequiredService<CategoriaStore>(),
                CreateHomeNavigationService(s)));
            services.AddTransient<LoginViewModel>(CreateLoginViewModel);
            services.AddTransient<ListaDeCategoriasViewModel>(s => new ListaDeCategoriasViewModel(
                s.GetRequiredService<PeopleStore>(),
                CreateAddPersonNavigationService(s)));
            services.AddTransient<AddCategoriaViewModel>(s => new AddCategoriaViewModel(
                s.GetRequiredService<PeopleStore>(),
                s.GetRequiredService<CloseModalNavigationService>()
                ));
            services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewModel);
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<LoginViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginViewModel>());
        }

        private INavigationService CreateAddPersonNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddCategoriaViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddCategoriaViewModel>());
        }

        private INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<CategoriaViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<CategoriaViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreatePeopleListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ListaDeCategoriasViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ListaDeCategoriasViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private LoginViewModel CreateLoginViewModel(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new CompositeNavigationService(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateAccountNavigationService(serviceProvider));

            return new LoginViewModel(
                serviceProvider.GetRequiredService<CategoriaStore>(),
                navigationService);
        }

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(serviceProvider.GetRequiredService<CategoriaStore>(),
                CreateHomeNavigationService(serviceProvider),
                CreateAccountNavigationService(serviceProvider),
                CreateLoginNavigationService(serviceProvider),
                CreatePeopleListingNavigationService(serviceProvider));
        }
    }
}
