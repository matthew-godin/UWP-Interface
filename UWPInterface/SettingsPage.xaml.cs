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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPInterface
{
    class InvalidMusicVolumeException : Exception { }

    class InvalidSoundVolumeException : Exception { }

    class InvalidRenderDistanceException : Exception { }

    class InvalidControllerException : Exception { }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        const int MUTE = 0, MAX_VOLUME = 100, MIN_RENDER_DISTANCE = 5, MAX_RENDER_DISTANCE = 100;

        int musicVolume, soundVolume, renderDistance;

        public int MusicVolume
        {
            get
            {
                return musicVolume;
            }
            set
            {
                if (musicVolume < MUTE || musicVolume > MAX_VOLUME)
                {
                    throw new InvalidMusicVolumeException();
                }
                musicVolume = value;
            }
        }
        public int SoundVolume
        {
            get
            {
                return soundVolume;
            }
            set
            {
                if (value < MUTE || value > MAX_VOLUME)
                {
                    throw new InvalidSoundVolumeException();
                }
                soundVolume = value;
            }
        }
        public bool AutoSave { get; set; }
        public int RenderDistance
        {
            get
            {
                return renderDistance;
            }
            set
            {
                if (value < MIN_RENDER_DISTANCE || value > MAX_RENDER_DISTANCE)
                {
                    throw new InvalidRenderDistanceException();
                }
                renderDistance = value;
            }
        }

        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //using (StreamWriter writer = new StreamWriter(new FileStream("../../../Saves/save0.txt", FileMode.Append)))
            //{
            //    writer.WriteLine("Music Volume: " + MusicVolume);
            //}
            this.Frame.Navigate(typeof(MainPage));
        }

        private void AutoSaveToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

        }

        private void MusicVolumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void RenderDistanceSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void SoundVolumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void ControllerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
