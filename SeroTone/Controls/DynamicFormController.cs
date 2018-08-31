using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static SeroTone.Utils.Global;

namespace SeroTone.Controls
{
    class DynamicFormController
    {


        /// <summary>
        /// This method accepts any string found in the Utils.Global.DYNAMIC_ELEMENTS[]
        /// array, and returns the corresponding, pre-configured element that can then
        /// be applied to the UI controlled by the calling class.
        /// </summary>
        /// <param name="elementName">Any value from Utils.Global.DYNAMIC_ELEMENTS[]</param>
        /// <returns></returns>
        public static UIElement CreateFormElement(string elementName)
        {
            UIElement dynamicElement = new UIElement();

            if (!string.IsNullOrEmpty(elementName))
            {
                if (elementName.Equals(DYNAMIC_ELEMENTS[0]))
                {
                    dynamicElement = InputDataTextBlock(DYNAMIC_ELEMENTS[0]);
                }
            }
            return dynamicElement;
        }

        /// <summary>
        /// This method constructs and returns the TextBlock_InputData UI element
        /// My first ever attempt to do so with any WPF UI element.
        /// </summary>
        /// <param name="tbName">The string given from the Global.DYNAMIC_ELEMENTS array, used as the name of the element</param>
        /// <returns></returns>
        private static TextBlock InputDataTextBlock(string tbName)
        {
            // instantiate
            TextBlock inputTB = new TextBlock();
            inputTB.Name = tbName;

            // format
            inputTB.Margin = new Thickness(5);
            inputTB.Padding = new Thickness(2);
            inputTB.Foreground = Brushes.White;
            inputTB.FontFamily = new FontFamily(INPUT_DATA_FONT);

            // layout & scrolling
            Grid.SetColumn(inputTB, 6);
            Grid.SetRow(inputTB, 5);
            Grid.SetColumnSpan(inputTB, 5);
            Grid.SetRowSpan(inputTB, 23);
            ScrollViewer.SetCanContentScroll(inputTB, true);
            ScrollViewer.SetHorizontalScrollBarVisibility(inputTB, ScrollBarVisibility.Auto);
            ScrollViewer.SetVerticalScrollBarVisibility(inputTB, ScrollBarVisibility.Auto);

            // allow for a dynamic number of gradient stops 
            RadialGradientBrush rgb = new RadialGradientBrush();
            for (int i = 0; i < GRAD_STOP_COLORS.Length; i++)
            {
                rgb.GradientStops.Add(
                    new GradientStop(
                        Color.FromArgb(
                            GRAD_STOP_COLORS[i][0], GRAD_STOP_COLORS[i][1], GRAD_STOP_COLORS[i][2], GRAD_STOP_COLORS[i][3]
                        ), GRAD_STOP_OFFSETS[i]
                    )
                );
            }

            // set background brush and return
            inputTB.Background = rgb;
            return inputTB;
        }
    }
}
