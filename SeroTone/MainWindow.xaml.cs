using Microsoft.Win32;
using SeroTone.Objects;
using System;
using System.Collections.Generic;
using System.IO;
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
using static SeroTone.Controls.GlobalVarController;


namespace SeroTone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string OUTPUT_FILENAME;

        public MainWindow()
        {
            InitializeComponent();
            Height = SystemParameters.PrimaryScreenHeight * 0.25;
            Width = SystemParameters.PrimaryScreenWidth * 0.25;
            //WriteTones(@"D:\dev\output\SeroTone\test.wav");
        }



        private void Button_SelectInput_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Please select the file containing your input data...";

            if (dialog.ShowDialog() == true)
            {
                // load data into a new window...

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_SelectOutput_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Please specify the name of the file to which output will be saved.";

            if (dialog.ShowDialog() == true)
            {
                if (!string.IsNullOrEmpty(dialog.FileName))
                {
                    OUTPUT_FILENAME = dialog.FileName;
                    if (!dialog.FileName.EndsWith(OUTPUT_SUFFIX))
                    {
                        OUTPUT_FILENAME += OUTPUT_SUFFIX;
                    }
                }
                Button_SelectOutput.FontStyle = FontStyles.Normal;
                Button_SelectOutput.Content = OUTPUT_FILENAME;
            }
        }

        private void Button_Go1_Click(object sender, RoutedEventArgs e)
        {
            string input;
            if (!string.IsNullOrEmpty(TextBox_Input1.Text))
            {
                input = TextBox_Input1.Text;
                FrequencyTable ft = new FrequencyTable();
                TextBox_Output1.Text = ft.GetLowest(input).ToString();
            }
        }

        private void Button_Go2_Click(object sender, RoutedEventArgs e)
        {
            string input;
            if (!string.IsNullOrEmpty(TextBox_Input2.Text))
            {
                input = TextBox_Input2.Text;
                FrequencyTable ft = new FrequencyTable();
                TextBox_Output2.Text = ft.GetAtOctave(input, 3).ToString();
            }
        }

        private void Button_Go3_Click(object sender, RoutedEventArgs e)
        {
            string input;
            if (!string.IsNullOrEmpty(TextBox_Input3.Text))
            {
                input = TextBox_Input3.Text;
            }
        }

        private void Button_Make_Click(object sender, RoutedEventArgs e)
        {
            //1: make sure input data is valid
            //2: make sure output selection is valid
            //3: make sure variables used in composition are valid 
        }
    }
}
