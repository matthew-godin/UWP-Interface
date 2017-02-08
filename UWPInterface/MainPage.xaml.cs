using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
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
            this.Frame.Navigate(typeof(LoadGamePage));
            //Display.Children.Clear();
            //Display.RowDefinitions.Clear();
            //Display.ColumnDefinitions.Clear();
            //Columns = new Grid();
            //Columns.Children.Clear();
            //Columns.RowDefinitions.Clear();
            //Columns.ColumnDefinitions.Clear();
            //Button[] arrayOfSaveButtons = new Button[NUM_SAVES];
            //SetDisplayForLoadGame();
            //SetSaveButtons(arrayOfSaveButtons);
        }

        void SetDisplayForLoadGame()
        {
            Display.Width = Window.Current.Bounds.Width;
            Display.Height = Window.Current.Bounds.Height;
            BackButton = new Button();
            
            BackButton.Margin = new Thickness(10, 10, 10, 10);
            BackButton.Width = 300;
            BackButton.Height = 50;
            BackButton.Content = "Back";
            BackButton.FontSize = 30;
            BackButton.HorizontalAlignment = HorizontalAlignment.Left;
            BackButton.VerticalAlignment = VerticalAlignment.Bottom;


            BackButton.SetValue(Grid.RowProperty, 0);
            RowDefinition firstRow = new RowDefinition();
            firstRow.Height = new GridLength(10, GridUnitType.Star);
            Display.RowDefinitions.Add(firstRow);
            Display.Children.Add(BackButton);

            Columns.Width = Display.Width;
            Columns.HorizontalAlignment = HorizontalAlignment.Stretch;
            Columns.SetValue(Grid.RowProperty, 1);
            RowDefinition secondRow = new RowDefinition();
            secondRow.Height = new GridLength(90, GridUnitType.Star);
            Display.RowDefinitions.Add(secondRow);
            Display.Children.Add(Columns);
        }

        void SetSaveButtons(Button[] buttons)
        {
            Image currentImage;
            BitmapImage currentSource;
            Grid currentGrid;
            RowDefinition[] currentRowDefinitions = new RowDefinition[5];
            TextBlock[] currentTextBlocks = new TextBlock[4];
            Image[] savesImages = new Image[3];


            for (int i = 0; i < NUM_SAVES; ++i)
            {
                Columns.ColumnDefinitions.Add(new ColumnDefinition());
                buttons[i] = new Button();
                Columns.Children.Add(buttons[i]);
                buttons[i].Margin = new Thickness(i == 1 || i == 2 ? 20 : 40, 0, i == 0 || i == 1 ? 20 : 40, 40);
                buttons[i].Width = 500;
                buttons[i].Height = 800;
                buttons[i].SetValue(Grid.ColumnProperty, i);

                currentImage = new Image();
                currentRowDefinitions[0] = new RowDefinition();
                currentRowDefinitions[0].Height = new GridLength(30, GridUnitType.Star);
                currentGrid = new Grid();
                currentGrid.Children.Clear();
                currentGrid.RowDefinitions.Clear();
                currentGrid.ColumnDefinitions.Clear();
                currentGrid.RowDefinitions.Add(currentRowDefinitions[0]);
                currentImage.SetValue(Grid.RowProperty, 0);
                currentGrid.Children.Add(currentImage);
                
                currentGrid.Width = 500;
                currentGrid.HorizontalAlignment = HorizontalAlignment.Center;
                //Columns.ColumnDefinitions.Add(new ColumnDefinition());
                currentGrid.SetValue(Grid.ColumnProperty, i);
                Columns.Children.Add(currentGrid);
                currentSource = new BitmapImage();
                currentImage.Width = currentSource.DecodePixelWidth = 240;
                currentImage.Height = currentSource.DecodePixelHeight = 180;
                currentSource.UriSource = new Uri(currentImage.BaseUri, "Assets/SavesScreenshots/save" + i + ".bmp");
                currentImage.Source = currentSource;
                //currentImage.HorizontalAlignment = HorizontalAlignment.Center;

                currentTextBlocks[0] = new TextBlock();
                currentTextBlocks[0].Text = "\t\t\tSave Name";
                currentTextBlocks[0].FontSize = 20;
                currentTextBlocks[0].Width = 500;
                //currentTextBlocks[0].HorizontalAlignment = HorizontalAlignment.Center;
                currentRowDefinitions[1] = new RowDefinition();
                currentRowDefinitions[1].Height = new GridLength(10, GridUnitType.Star);
                currentGrid.RowDefinitions.Add(currentRowDefinitions[1]);
                currentTextBlocks[0].SetValue(Grid.RowProperty, 1);
                currentGrid.Children.Add(currentTextBlocks[0]);

                currentTextBlocks[1] = new TextBlock();
                currentTextBlocks[1].Text = "\t\t\tTime Played: 00:00";
                currentTextBlocks[1].FontSize = 20;
                currentTextBlocks[1].Width = 500;
                //[1].HorizontalAlignment = HorizontalAlignment.Center;
                currentRowDefinitions[2] = new RowDefinition();
                currentRowDefinitions[2].Height = new GridLength(10, GridUnitType.Star);
                currentGrid.RowDefinitions.Add(currentRowDefinitions[2]);
                currentTextBlocks[1].SetValue(Grid.RowProperty, 2);
                currentGrid.Children.Add(currentTextBlocks[1]);

                currentTextBlocks[2] = new TextBlock();
                currentTextBlocks[2].Text = "\t\t\t0%";
                currentTextBlocks[2].FontSize = 20;
                currentTextBlocks[2].Width = 500;
                //currentTextBlocks[2].HorizontalAlignment = HorizontalAlignment.Center;
                currentRowDefinitions[3] = new RowDefinition();
                currentRowDefinitions[3].Height = new GridLength(10, GridUnitType.Star);
                currentGrid.RowDefinitions.Add(currentRowDefinitions[3]);
                currentTextBlocks[2].SetValue(Grid.RowProperty, 3);
                currentGrid.Children.Add(currentTextBlocks[2]);

                currentTextBlocks[3] = new TextBlock();
                currentTextBlocks[3].Text = "\t\t\tPlace Name";
                currentTextBlocks[3].FontSize = 20;
                currentTextBlocks[3].Width = 500;
                //currentTextBlocks[3].HorizontalAlignment = HorizontalAlignment.Center;
                currentRowDefinitions[4] = new RowDefinition();
                currentRowDefinitions[4].Height = new GridLength(10, GridUnitType.Star);
                currentGrid.RowDefinitions.Add(currentRowDefinitions[4]);
                currentTextBlocks[3].SetValue(Grid.RowProperty, 4);
                currentGrid.Children.Add(currentTextBlocks[3]);
            }
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SettingsPage));
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewGamePage));
        }

        private void CreditsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreditsPage));
        }
    }
}
