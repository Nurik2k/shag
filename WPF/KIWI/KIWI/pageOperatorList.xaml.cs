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

namespace KIWI
{
    /// <summary>
    /// Interaction logic for pageOperatorList.xaml
    /// </summary>
    public partial class pageOperatorList : Page
    {
        public pageOperatorList()
        {
            InitializeComponent();
            List<Operator> operators = new List<Operator>();
            operators.Add(new Operator()
            {
                Prefix = "+7 777",
                Logo = "https://play-lh.googleusercontent.com/YSMd2aaFMmeUZrnivoPFXVmfE6756FefmGhKAWEIvbvMju5jhlIEj_bXlKiP1wMyiPk",
                Name = "Beeline",
                Percent = 0.5
            });
            lvOperatorList.ItemsSource = operators;
        }
        private void btnEditData_Click(object sender, RoutedEventArgs e)
        {
            Operator data = (Operator)lvOperatorList.SelectedItem;
        }
        
    }
    
}
