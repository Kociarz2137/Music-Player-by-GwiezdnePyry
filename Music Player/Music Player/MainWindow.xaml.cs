using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Forms;
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
    string folderPath = @"C:/";
    
    public MainWindow()
    {
        InitializeComponent();
        
    }
    
    private void MP3FilesList()
    {
        if (Directory.Exists(folderPath)) 
        { 
            string[] mp3Files = Directory.GetFiles(folderPath, "*.mp3"); 
            ListBoxMP3.ItemsSource = mp3Files.Select(Path.GetFileName);
        }
        else 
        { 
            // MessageBox.Show("Folder does not exist.");
            Console.WriteLine("hello");
        }
        
    }
    
    private void PlayButton_Click(object sender, RoutedEventArgs e)
    {
        string selectedFile = ListBoxMP3.SelectedItem as string;
        if (!string.IsNullOrEmpty(selectedFile))
        {
            mediaPlayer.Open(new Uri(Path.Combine(folderPath, selectedFile)));
            mediaPlayer.Play();
        }
        else
        {
            MessageBox.Show("Please select an .mp3 file.");
        }
    }

    private void StopButton_Click(object sender, RoutedEventArgs e)
    {          
        mediaPlayer.Stop();
    }

    private void directoryApplyClick(object sender, RoutedEventArgs e)
    {
        string folderDirectory = DirectoryTextBox.Text;
        folderPath = folderDirectory;
        MessageBox.Show("Success! The directory is now set to: " + folderPath);
        if (Directory.Exists(folderDirectory))
        {
            MP3FilesList();
        }
        else
        {
            MessageBox.Show("Directory '" + folderDirectory + "' does not exists");
        }
    }
    
    // TODO: Optimize the code
    // TODO: Fix the bug where stop button does not stop the music but only plays it over again from start
    // TODO: Remove the handlers of not choosen directory
    
    
    
}