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
using System.Windows.Shapes;

namespace SeroTone
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        public DataWindow()
        {
            InitializeComponent();
            Height = SystemParameters.PrimaryScreenHeight * 0.25;
            Width = SystemParameters.PrimaryScreenWidth * 0.25;
        }

        private void Button_SelectInput_New_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow.Button
        }
    }
}
