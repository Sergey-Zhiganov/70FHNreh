using MaterialDesignThemes.Wpf;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace ТЫндекс_Музыка
{
    public partial class MainWindow : Window
    {
        private List<string> music_files = new List<string>();
        private List<string> music_names = new List<string>();
        private static List<string> music_history_files = new List<string>();
        private static List<string> music_history_names = new List<string>();
        private bool is_playing = false;
        private bool is_repeating = false;
        private bool is_shuffle = false;
        private bool check_start = false;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            mediaElement.Volume = 0.3;
            Thread musicseconds = new Thread(() => { MusicSeconds(); }) ;
            musicseconds.Start();
        }

        private void MusicSeconds()
        {
            while (true)
            {
                Dispatcher.Invoke(() =>
                {
                    if (check_start)
                    {
                        while (true) {
                            try
                            {
                                MusicSlider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;
                                check_start = false;
                                return;
                            }
                            catch { Thread.Sleep(100); }
                        }
                    }
                    try
                    {
                        Music_label.Content = mediaElement.Position.Minutes + ":" + mediaElement.Position.Seconds + " / " + mediaElement.NaturalDuration.TimeSpan.Minutes + ":" + mediaElement.NaturalDuration.TimeSpan.Seconds;
                    }
                    catch {
                        Music_label.Content = "0:00 / 0:00";
                    }
                    if (is_playing && MusicSlider.Value != MusicSlider.Maximum)
                    {
                        MusicSlider.Value = mediaElement.Position.TotalSeconds;
                    }
                    if (MusicSlider.Value == MusicSlider.Maximum && MusicSlider.Maximum > 0)
                    {
                        MusicEnded();
                    }
                });
                Thread.Sleep(1000);
            }
        }

        private void Start_Music(object sender, RoutedEventArgs e)
        {
            Play_Music(music_files[ListMusic.SelectedIndex]);
        }

        private void Play_Music(string path, string music_name = null)
        {
            if (music_name == null)
            {
                music_name = music_names[ListMusic.SelectedIndex];
            }
            MusicSlider.Value = 0;
            MusicSlider.Maximum = 0;
            try
            {
                mediaElement.Source = new Uri(path);
                mediaElement.Play();
            }
            catch { return; }
            music_history_files.Add(path);
            music_history_names.Add(music_name);
            check_start = true;
            is_playing = true;
        }

        private void Get_Music_Name(string[] files, string current = null)
        {
            music_files = new List<string>();
            music_names = new List<string>();
            foreach (string file in files)
            {
                if (file.EndsWith(".mp3") || file.EndsWith(".wav") || file.EndsWith(".flac") || file.EndsWith(".aac") || file.EndsWith(".ogg"))
                {
                    string item = file.Substring(file.LastIndexOf("\\") + 1);
                    if (current == item)
                    {
                        ListMusic.SelectedItem = item;
                        current = null;
                    }
                    music_files.Add(file);
                    music_names.Add(item);
                }
            }
            ListMusic.ItemsSource = music_names;
        }

        private void Chose_File(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog { IsFolderPicker = true };
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                string[] files = Directory.GetFiles(dialog.FileName);
                Get_Music_Name(files);
                if (music_files.Count > 0)
                {
                    ListMusic.SelectedIndex = 0;
                }
            }
        }

        private void ChangeMusic(int change)
        {
            try
            {
                if (ListMusic.SelectedItem == null)
                {
                    ListMusic.SelectedIndex = 0;
                }
                if (ListMusic.SelectedIndex + change > music_files.Count() - 1)
                {
                    ListMusic.SelectedIndex = 0;
                }
                else if (ListMusic.SelectedIndex + change < 0)
                {
                    ListMusic.SelectedIndex = music_files.Count() - 1;
                }
                else
                {
                    ListMusic.SelectedIndex += change;
                }
            }
            catch { }
        }

        private void MusicEnded()
        {
            if (is_repeating)
            {
                ChangeMusic(0);
            }
            else
            {
                ChangeMusic(1);
            }
        }

        private void PlayPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Play.Kind == PackIconKind.Play)
                {
                    Play.Kind = PackIconKind.Pause;
                    mediaElement.Pause();
                    is_playing = false;
                }
                else
                {
                    mediaElement.Play();
                    Play.Kind = PackIconKind.Play;
                    is_playing = true;
                }
            }
            catch { }
        }
        private void SkipNext(object  sender, RoutedEventArgs e)
        {
            ChangeMusic(1);
        }
        private void SkipBackward(object sender, RoutedEventArgs e)
        {
            ChangeMusic(-1);
        }
        private void Repeat(object sender, RoutedEventArgs e)
        {
            if (is_repeating)
            {
                is_repeating = false;
            }
            else
            {
                is_repeating = true;
            }
        }
        private void Shuffle(object  sender, RoutedEventArgs e)
        {
            try
            {   if (music_files.Count == 0)
                {
                    return;
                }
                string current_music = ListMusic.SelectedValue.ToString();
                string[] files;
                if (is_shuffle)
                {
                    music_files.Sort();
                    files = music_files.ToArray();
                }
                else
                {
                    files = music_files.OrderBy(x => random.Next()).ToArray();
                }
                is_shuffle = !is_shuffle;
                Get_Music_Name(files, current_music);
            }
            catch { }
        }

        private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement.Volume = Volume.Value / 10;
        }

        private void MusicSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement.Position = TimeSpan.FromSeconds(MusicSlider.Value);
        }

        private void History_Show(object sender, RoutedEventArgs e)
        {
            History history = new History();
            history.HistoryList.ItemsSource = music_history_names;
            bool? result = history.ShowDialog();
            if (result == true)
            {
                int index = history.HistoryList.SelectedIndex;
                string item = music_history_names[index];
                ListMusic.SelectedItem = item;
                if (ListMusic.SelectedItem != null) {
                    Start_Music(null, null);
                }
                else {
                    Play_Music(music_history_files[index], music_history_names[index]);
                }
                
            }
        }
    }
}