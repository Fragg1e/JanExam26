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

        public void CreateRobots()
        {
            HouseholdRobot hr1 = new("HouseBot", 25, 25);
            HouseholdRobot hr2 = new("GardenMate", 25, 25);
            HouseholdRobot hr3 = new("Housemate 3000", 25, 25);

            hr2.DownloadSkill(Robot.HouseholdSkill.Gardening);
            hr3.DownloadSkill(Robot.HouseholdSkill.Laundry);
            hr3.DownloadSkill(Robot.HouseholdSkill.Cooking);

            DeliveryRobot dr1 = new("DeliverBot", 25, 25, Robot.DeliveryMode.Walking, 100);
            DeliveryRobot dr2 = new("FlyBot", 25, 25, Robot.DeliveryMode.Flying, 100);
            DeliveryRobot dr3 = new("Driver", 25, 25, Robot.DeliveryMode.Driving, 100);

        }
    }



    abstract class Robot
    {
        string RobotName { get; set; }
        double PowerCapacityKWH { get; set; }
        double CurrentPowerKWH { get; set; }

        public Robot(string robotName, double powerCapacityKWH, double currentPowerKWH)
        {
            RobotName = robotName;
            PowerCapacityKWH = powerCapacityKWH;
            CurrentPowerKWH = currentPowerKWH;
        }

        public double GetBatteryPercentage()
        {
            double batteryPercentage = (CurrentPowerKWH / PowerCapacityKWH) * 100;

            return batteryPercentage;
        }

        public string DisplayBatteryInformation()
        {
            return $"Battery Information\nCapacity: {PowerCapacityKWH} kWh\nCurrent Power: {CurrentPowerKWH} kWh\nBattery Level: {GetBatteryPercentage()}%";
        }

        public string ChargeRobot()
        {
            if(CurrentPowerKWH == PowerCapacityKWH)
            {
                return "Robot is already fully charged.";
            }
            double chargeTime = (100 - GetBatteryPercentage()) * 10 ;
            CurrentPowerKWH = PowerCapacityKWH;

            return $"Robot fully charged. Time taken: {chargeTime} mins";
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
        private List<HouseholdSkill>? Skills { get; set; }

        public HouseholdRobot(string robotName, double powerCapacityKWH, double currentPowerKWH)
            : base(robotName, powerCapacityKWH, currentPowerKWH)
        {
            DownloadSkill(HouseholdSkill.Cleaning);
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

        public void DownloadSkill(HouseholdSkill skill)
        {
            Skills.Add(skill);

        }


    }

    class DeliveryRobot : Robot
    {
        DeliveryMode ModeOfDelivery { get; set; }
        double MaxLoadKG { get; set; }

        public DeliveryRobot(string robotName, double powerCapacityKWH, double currentPowerKWH, DeliveryMode modeOfDelivery, double maxLoadKG)
            : base(robotName, powerCapacityKWH, currentPowerKWH)
        {
            ModeOfDelivery = modeOfDelivery;
            MaxLoadKG = maxLoadKG;
        }


        public override string DescribeRobot()
        {
            return $"I am a delivery robot.\n\nI specialize in delivery by {ModeOfDelivery}\n\nThe maximum load I can carry is {MaxLoadKG}\n\n{DisplayBatteryInformation()}";
        }

        





    }
   

}