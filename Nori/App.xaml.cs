using Microsoft.Extensions.DependencyInjection;

namespace Nori
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

         
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}