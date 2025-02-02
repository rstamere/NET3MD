using NET1MDversion2;

namespace NET2MDversion8
{
    public partial class App : Application
    {
        public App() //savienojam App ar schoolManager, lai butu piekluve datiem un metodem no 1. MD
        {
            InitializeComponent();

            MainPage = new AppShell();
            SchoolInfo schoolInfo = new SchoolInfo();
            schoolMan = new schoolManager(schoolInfo);
            schoolMan.createTestData();
            //schoolMan.addAssignment();
            //BindingContext = schoolInfo.Get;
            //BindingContext = schoolMan;
            Application.Current.BindingContext = schoolMan.SchoolInfo;
        }
        public static schoolManager? schoolMan { get; set; } = new schoolManager(new SchoolInfo()); //es ceru, ka stradas tagad :')
    }
}
