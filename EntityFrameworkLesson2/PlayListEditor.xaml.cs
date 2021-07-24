using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EntityFrameworkLesson2
{
    /// <summary>
    /// Interaction logic for PlayListEditor.xaml
    /// </summary>
    public partial class PlayListEditor : Window
    {
        ViewModel viewModel;
        public PlayListEditor(ViewModel vm)
        {
            InitializeComponent();
            this.viewModel = vm;
            this.DataContext = vm;
        }

        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Image"; // Default file name
            dlg.DefaultExt = ".jpg"; // Default file extension
            dlg.Filter = "Text documents (.jpg)|*.jpg"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                if (viewModel.SelectedPlaylist.CoverImage == null)
                {
                    //MessageBox.Show($"1 {dlg.FileName}");
                    viewModel.SelectedPlaylist.CoverImage = viewModel.db.CoverImages.Add(new CoverImage { Path = dlg.FileName});
                    viewModel.SelectedPlaylist.CoverImage.Path = dlg.FileName;
                    Uri fileUri = new Uri(dlg.FileName);
                    playlistImage.Source = new BitmapImage(fileUri);

                }
                else { 
                    //MessageBox.Show($"2 {dlg.FileName}");
                    
                    viewModel.SelectedPlaylist.CoverImage.Path=dlg.FileName;
                    Uri fileUri = new Uri(dlg.FileName);
                    playlistImage.Source = new BitmapImage(fileUri);
                }
                viewModel.db.SaveChanges();
            }
        }

        private void PlaylistsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (PlaylistsListBox.SelectedItem == null || (PlaylistsListBox.SelectedItem as Playlist).CoverImage == null)
            {
                return;
            }
            string path = (PlaylistsListBox.SelectedItem as Playlist).CoverImage.Path;
            Uri fileUri = new Uri(path);
            playlistImage.Source = new BitmapImage(fileUri);
        }
    }
}
