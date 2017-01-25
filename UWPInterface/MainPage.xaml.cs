using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPInterface
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        const int NUM_SAVES = 3, NUM_ROWS = 2;

        Grid Columns { get; set; }
        Button BackButton { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {
            Display.Children.Clear();
            Display.RowDefinitions.Clear();
            Display.ColumnDefinitions.Clear();
            Columns = new Grid();
            Columns.Children.Clear();
            Columns.RowDefinitions.Clear();
            Columns.ColumnDefinitions.Clear();
            Button[] arrayOfSaveButtons = new Button[NUM_SAVES];
            SetSaveButtons(arrayOfSaveButtons);
            SetDisplayForLoadGame();
        }

        void SetDisplayForLoadGame()
        {
            RowDefinition firstRow = new RowDefinition();
            firstRow.Height = new GridLength(10, GridUnitType.Star);
            Display.RowDefinitions.Add(firstRow);
            RowDefinition secondRow = new RowDefinition();
            secondRow.Height = new GridLength(90, GridUnitType.Star);
            Display.RowDefinitions.Add(secondRow);
            BackButton = new Button();
            BackButton.Margin = new Thickness(10, 10, 10, 10);
            BackButton.Width = 300;
            BackButton.Height = 50;
            BackButton.Content = "Back";
            BackButton.FontSize = 30;
            BackButton.HorizontalAlignment = HorizontalAlignment.Left;
            BackButton.VerticalAlignment = VerticalAlignment.Bottom;
            BackButton.SetValue(Grid.RowProperty, 0);
            Display.Children.Add(BackButton);
            Columns.SetValue(Grid.RowProperty, 1);
            Display.Children.Add(Columns);
        }

        void SetSaveButtons(Button[] buttons)
        {
            for (int i = 0; i < NUM_SAVES; ++i)
            {
                Columns.ColumnDefinitions.Add(new ColumnDefinition());
                buttons[i] = new Button();
                buttons[i].Margin = new Thickness(40, 0, 0, 40);
                buttons[i].Width = 500;
                buttons[i].Height = 800;
                buttons[i].SetValue(Grid.ColumnProperty, i);
                Columns.Children.Add(buttons[i]);
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Columns.Children.Clear();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Columns.Children.Clear();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Columns.Children.Clear();
        }
    }
}
