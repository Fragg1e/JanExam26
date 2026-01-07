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

        public enum Position
        {
            Goalkeeper,
            Defender,
            Midfielder,
            Forward
        }

        public enum Position
        {
            Goalkeeper,
            Defender,
            Midfielder,
            Forward
        }





    }
}