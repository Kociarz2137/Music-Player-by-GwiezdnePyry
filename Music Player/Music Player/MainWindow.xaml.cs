using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using Path = System.IO.Path;

namespace Music_Player;

public partial class MainWindow : Window
{
    
    MediaPlayer mediaPlayer = new MediaPlayer();
    
    public MainWindow()
    {
        InitializeComponent();
        LoadMP3Files();
    }
    
    private void LoadMP3Files()
    {
        // Specify the folder path where your .mp3 files are located
        string folderPath = @"C:\";

        // Check if the folder exists
        if (Directory.Exists(folderPath))
        {
            // Get all .mp3 files in the folder
            string[] mp3Files = Directory.GetFiles(folderPath, "*.mp3");

            // Display the .mp3 files in a ListBox
            ListBoxMP3.ItemsSource = mp3Files.Select(Path.GetFileName);
        }
        else
        {
            MessageBox.Show("Folder does not exist.");
        }
    }
    
    private void PlayButton_Click(object sender, RoutedEventArgs e)
    {
        mediaPlayer.Open(new Uri("C:/music.mp3"));
        mediaPlayer.Play();
    }
}