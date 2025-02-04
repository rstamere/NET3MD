using Microsoft.Extensions.Configuration;
using NET1MDversion2;

namespace NET2MDversion8
{
    public partial class App : Application
    {

        public IConfiguration configuration { get; set; }
        public App(IConfiguration _configuration) //savienojam App ar schoolManager, lai butu piekluve datiem un metodem no 1. MD
        {
            configuration = _configuration;
            InitializeComponent();

            MainPage = new AppShell();
            SchoolInfo schoolInfo = new SchoolInfo();
            schoolMan = new schoolManager(schoolInfo, configuration["ConnectionStrings:SchoolCon"]);
            //schoolMan.createTestData();
            Application.Current.BindingContext = schoolMan.SchoolInfo;
        }
        public static schoolManager? schoolMan { get; set; } = new schoolManager(new SchoolInfo()); //es ceru, ka stradas tagad :')
    }
}
