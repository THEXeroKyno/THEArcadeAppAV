namespace THEArcadeAppAV
{
    public partial class App : Application
    {
        public static UserRepository UserRepo { get; set; }
        public App(UserRepository repo)
        {
            InitializeComponent();
            UserRepo = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}