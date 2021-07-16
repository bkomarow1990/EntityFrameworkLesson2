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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityFrameworkLesson2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Initializer init = new Initializer();

        ViewModel vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
            //try { 
            //  db.Countries.Add(new Country { Name= "Sweden" });
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void addTrackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PlaylistsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please, select playlist");
                return;
            }
            if (vm.SelectedTrack == null)
            {
                MessageBox.Show("Please, select track");
                return;
            }
            try
            {
                var playlist = PlaylistsComboBox.SelectedItem as Playlist;
                if (playlist.Tracks.Contains(vm.SelectedTrack))
                {
                    MessageBox.Show("Track is exists");
                    return;
                }
                playlist.Tracks.Add(vm.SelectedTrack);
                vm.db.SaveChanges();
                MessageBox.Show("Track was added in playlist");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteTrackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PlaylistsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please, select playlist");
                return;
            }
            if (vm.SelectedTrack == null)
            {
                MessageBox.Show("Please, select track");
                return;
            }
            var playlist = PlaylistsComboBox.SelectedItem as Playlist;
            if (!playlist.Tracks.Contains(vm.SelectedTrack))
            {
                MessageBox.Show("Track isn`t exists");
                return;
            }
            try
            {
               
                playlist.Tracks.Remove(vm.SelectedTrack);
                vm.db.SaveChanges();
                MessageBox.Show("Track was deleted in playlist");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditPlaylistBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayListEditor pe = new PlayListEditor(vm);
            pe.Show();
        }
    }
}
