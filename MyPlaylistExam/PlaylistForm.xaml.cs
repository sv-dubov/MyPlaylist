using MyPlaylistExam.Entities;
using MyPlaylistExam.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MyPlaylistExam
{
    /// <summary>
    /// Interaction logic for PlaylistForm.xaml
    /// </summary>
    public partial class PlaylistForm : Window
    {
        private ObservableCollection<PlaylistObserveViewModel> tracks = new ObservableCollection<PlaylistObserveViewModel>();
        public PlaylistForm()
        {
            InitializeComponent();
            using (EFContext context = new EFContext())
            {
                tracks = new ObservableCollection<PlaylistObserveViewModel>
                                    (
                                    context.Playlists.Select(p => new PlaylistObserveViewModel
                                    {
                                        Id = p.Id,
                                        NameList = p.NameList,
                                        UserId = p.UserId ?? 0
                                    }).ToList());
                myDataGrid.ItemsSource = tracks;
            }
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            using (EFContext context = new EFContext())
            {
                Playlist playlist = new Playlist
                {
                    Id = int.Parse(id_txtbx.Text),
                    NameList = namelist_txtbx.Text
                };
                context.Playlists.Add(playlist);
                context.SaveChanges();
                tracks.Add(new PlaylistObserveViewModel
                {
                    Id = playlist.Id,
                    NameList = playlist.NameList
                });
            }
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            using (EFContext context = new EFContext())
            {
                if (myDataGrid.SelectedItem != null)
                {
                    var playlistView = (myDataGrid.SelectedItem as PlaylistObserveViewModel);
                    var playlist = context.Playlists.SingleOrDefault(p => p.Id == playlistView.Id);
                    if (playlist != null)
                    {
                        playlist.NameList = namelist_txtbx.Text;
                        context.SaveChanges();
                        playlistView.NameList = playlist.NameList;
                    }
                }
            }
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            using (EFContext context = new EFContext())
            {
                if (myDataGrid.SelectedItem != null)
                {
                    var playlistView = (myDataGrid.SelectedItem as PlaylistObserveViewModel);
                    var playlist = context.Playlists.SingleOrDefault(p => p.Id == playlistView.Id);
                    if (playlist != null)
                    {
                        tracks.Remove(playlistView);
                        context.Playlists.Remove(playlist);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            id_txtbx.Text = "";
            namelist_txtbx.Text = "";
        }
    }
}
