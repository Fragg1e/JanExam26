using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JanExam26
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    abstract class Robot
    {
        string RobotName { get; set; }
        double PowerCapacityKWH { get; set; }
        double CurrentPowerKWH {  get; set; }

        public Robot(string robotName, double powerCapacityKWH, double currentPowerKWH)
        {
            RobotName = robotName;
            PowerCapacityKWH = powerCapacityKWH;
            CurrentPowerKWH = currentPowerKWH;
        }

        public double GetBatteryPercentage()
        {
            double batteryPercentage = (CurrentPowerKWH / PowerCapacityKWH)*100;

            return batteryPercentage;
        }

        public string DisplayBatteryInformation()
        {
            return $"Battery Information\nCapacity: {PowerCapacityKWH} kWh\nCurrent Power: {CurrentPowerKWH} kWh\nBattery Level: {GetBatteryPercentage()}%";
        }

        public abstract string DescribeRobot();

        public override string ToString()
        {
            return $"{RobotName}";
        }

        public enum HouseholdSkill { Cooking, Cleaning, Laundry, Gardening, ChildCare }
        public enum DeliveryMode { Walking, Driving, Flying }


        





    }

    class HouseholdRobot : Robot
    {
        private List<HouseholdSkill> Skills { get; set; }

        public HouseholdRobot(string robotName, double powerCapacityKWH, double currentPowerKWH, HouseholdSkill skill)
            : base(robotName, powerCapacityKWH, currentPowerKWH)
        {
            Skills.Add(skill);
        }

        public override string DescribeRobot()
        {
            string skills = "";
            foreach (HouseholdSkill skill in Skills) 
            {
                skills += skill.ToString() + "\n";
            }
            return $"I am a household robot.\nI can help with chores around the house.\n\nHousehold robot skills:\n{skills}\n{DisplayBatteryInformation()}";
        }


    }

    class DeliveryRobot : Robot
    {
        DeliveryMode ModeOfDelivery {  get; set; }
        double MaxLoadKG { get; set; }

    }
}