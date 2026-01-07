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
    //Github Link - https://github.com/Fragg1e/JanExam26
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HouseholdRobot hr1 = new("HouseBot", 25, 25);
            this.DataContext = hr1.DescribeRobot() ;
        }

        public void CreateRobots()
        {
            List<Robot> robots = new List<Robot>();
            HouseholdRobot hr1 = new("HouseBot", 25, 25);
            HouseholdRobot hr2 = new("GardenMate", 25, 25);
            HouseholdRobot hr3 = new("Housemate 3000", 25, 25);

            hr2.DownloadSkill(Robot.HouseholdSkill.Gardening);
            hr3.DownloadSkill(Robot.HouseholdSkill.Laundry);
            hr3.DownloadSkill(Robot.HouseholdSkill.Cooking);

            DeliveryRobot dr1 = new("DeliverBot", 25, 25, Robot.DeliveryMode.Walking, 100);
            DeliveryRobot dr2 = new("FlyBot", 25, 25, Robot.DeliveryMode.Flying, 100);
            DeliveryRobot dr3 = new("Driver", 25, 25, Robot.DeliveryMode.Driving, 100);

            robots.Add(hr1);
            robots.Add(hr2);
            robots.Add(hr3);
            robots.Add(dr1);
            robots.Add(dr2);
            robots.Add(dr3);

            

        }

        private void ChargeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Charged robot");
        }

     

    }



    
   

}