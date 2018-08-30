using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeroTone.Controls
{
    class SharedEventsContoller
    {
        public static void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Please select the file containing your input data...";

            if (dialog.ShowDialog() == true)
            {
                // load data into a new window...
                
            }
        }
    }
}
