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

namespace Music_Player;

public partial class MainWindow : Window
{
    
    MediaPlayer mediaPlayer = new MediaPlayer();
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void PlayButton_Click(object sender, RoutedEventArgs e)
    {
        mediaPlayer.Open(new Uri("C:/music.mp3"));
        mediaPlayer.Play();
    }
}