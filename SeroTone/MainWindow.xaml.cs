using Microsoft.Win32;
using SeroTone.Objects;
using System.Windows;
using System.Configuration;
using System.Text;
using static SeroTone.Utils.Global;
using static SeroTone.Controls.DynamicFormController;
using static SeroTone.Controls.SettingsController;

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
            InitializeSettingsController();
            Height = SystemParameters.PrimaryScreenHeight * 0.25;
            Width = SystemParameters.PrimaryScreenWidth * 0.25;
            //WriteTones(@"D:\dev\output\SeroTone\test.wav");

            CreateDynamicControls();
            string dynElem = Properties.Settings.Default.DynamicElements[0];
            //byte[] gradStop1 = Properties.Settings.Default.GradientStopColor1;
            SettingsPropertyCollection props = Properties.Settings.Default.Properties;
            //props.Count

            
            //OutputB.Text = gradStop1.ToString();

            StringBuilder sb = new StringBuilder();

            foreach (var prop in props)
            {
                sb.Append(prop.ToString()).Append("; ");
            }

            OutputA.Text = "Properties.Settings.Default.DynamicElements[0] = " + Properties.Settings.Default.DynamicElements[0];
            OutputB.Text = "Properties.Settings.Default.Properties.Count = " + Properties.Settings.Default.Properties.Count.ToString();
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

        private void CreateDynamicControls()
        {



            // add to the window
            //AddChild(inputTB);
            RootGrid.Children.Add(CreateFormElement(DYNAMIC_ELEMENTS[0]));
        }

        private void GradientShift()
        {
            /**
             * On init:
             * < GradientStop Color = "Black" Offset = "0.218" />
             * < GradientStop Color = "#FF7E99FF" Offset = "0.367" />
             * < GradientStop Color = "Black" />
             * < GradientStop Color = "#FF7EFFA7" Offset = "0.474" />
             * < GradientStop Color = "#FFFF7E98" Offset = "0.758" />
             * < GradientStop Color = "#FFF5B6C3" Offset = "0.29" />
             * < GradientStop Color = "#FFF5EFB6" Offset = "1" />
             * */

            //RadialGradientBrush rgb = TextBlock_InputData.Background.
        }
    }
}
