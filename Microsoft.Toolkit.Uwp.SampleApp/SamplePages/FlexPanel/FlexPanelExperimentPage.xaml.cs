﻿using System;
using FlexPanelTest;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Microsoft.Toolkit.Uwp.SampleApp.SamplePages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class FlexPanelExperimentPage : Page
    {
        private static readonly Color[] Colors =
        {
            Windows.UI.Colors.Red, Windows.UI.Colors.Magenta, Windows.UI.Colors.Blue,
            Windows.UI.Colors.Cyan, Windows.UI.Colors.Green, Windows.UI.Colors.Yellow
        };

        private static readonly string[] DigitsText =
        {
            string.Empty, "One", "Two", "Three", "Four", "Five",
            "Six", "Seven", "Eight", "Nine", "Ten",
            "Eleven", "Twelve", "Thirteen", "Fourteen",
            "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        private static readonly string[] DecadeText =
        {
            string.Empty, string.Empty, "Twenty", "Thirty", "Forty", "Fifty",
            "Sixty", "Seventy", "Eighty", "Ninety"
        };

        public FlexPanelExperimentPage()
        {
            this.InitializeComponent();
            OnNumberStepperValueChanged(flexPanel, numberStepper.Value);
        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnNumberStepperValueChanged(object sender, double newValue)
        {
            if (flexPanel == null)
            {
                return;
            }

            int count = (int)newValue;

            while (flexPanel.Children.Count > count)
            {
                flexPanel.Children.RemoveAt(flexPanel.Children.Count - 1);
            }

            while (flexPanel.Children.Count < count)
            {
                int number = flexPanel.Children.Count + 1;
                string text = string.Empty;

                if (number < 20)
                {
                    text = DigitsText[number];
                }
                else
                {
                    text = DecadeText[number / 10] +
                           (number % 10 == 0 ? string.Empty : "-") +
                                DigitsText[number % 10];
                }

                var label = new TextBlock
                {
                    Text = text,
                    FontSize = 16 + (4 * ((number - 1) % 4)),
                    Foreground = new SolidColorBrush(Colors[(number - 1) % Colors.Length]),
                    TextWrapping = TextWrapping.Wrap,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                };
                var border = new Border
                {
                    Background = new SolidColorBrush(Windows.UI.Colors.LightGray),
                    BorderThickness = new Thickness(0),
                    Padding = new Thickness(0),
                    Margin = new Thickness(0),
                    Child = label,
                };

                flexPanel.Children.Add(border);
            }
        }

        private void OnFlexDirectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is EnumPicker picker)
            {
                var direction = (FlexDirection)picker.SelectedItem;
                flexPanel.Direction = direction;
            }
        }
    }
}
