namespace THEArcadeAppAV
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("arcade_main", typeof(MainPage));

            Routing.RegisterRoute("quiz_home", typeof(Quiz_HomePage));
            Routing.RegisterRoute("quiz_main", typeof(Quiz_MainPage));

            Routing.RegisterRoute("story_home", typeof(Story_HomePage));
            Routing.RegisterRoute("story_main", typeof(Story_MainPage));

            //Routing.RegisterRoute("Calculator", typeof(Calculator));

            Routing.RegisterRoute("Platform_home", typeof(Platform_HomePage));
            Routing.RegisterRoute("Platform_main", typeof(Platform_MainPage));

            Routing.RegisterRoute("Clicker_home", typeof(Clicker_HomePage));
            Routing.RegisterRoute("Clicker_main", typeof(Clicker_MainPage));

            Routing.RegisterRoute("signingup", typeof(Signup));
            Routing.RegisterRoute("Logingin", typeof(Login));

            Routing.RegisterRoute("simulator", typeof(Simulator));
        }
    }
}
