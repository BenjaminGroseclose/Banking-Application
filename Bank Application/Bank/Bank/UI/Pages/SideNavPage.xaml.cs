using Bank.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank.UI.Pages
{
    /// <summary>
    /// Interaction logic for SideNavPage.xaml
    /// </summary>
    public partial class SideNavPage : Page
    {
        public string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _firstName = value; }
        }

        public string _totalAmount;
        public string TotalAmount
        {
            get { return _totalAmount; }
            set { _totalAmount = value; }
        }

        public SideNavPage()
        {
            InitializeComponent();

        }

        public SideNavPage(string username)
        {

        }

    }
}
