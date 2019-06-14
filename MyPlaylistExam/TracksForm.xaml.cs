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
    /// Interaction logic for TracksForm.xaml
    /// </summary>
    public partial class TracksForm : Window
    {
        private ObservableCollection<TrackObserveViewModel> tracks = new ObservableCollection<TrackObserveViewModel>();
        private ObservableCollection<PlaylistObserveViewModel> pl = new ObservableCollection<PlaylistObserveViewModel>();

        public TracksForm()
        {
            InitializeComponent();

            using (EFContext context = new EFContext())
            {
                tracks = new ObservableCollection<TrackObserveViewModel>
                                    (
                                    context.Tracks.Select(t => new TrackObserveViewModel
                                    {
                                        Id = t.Id,
                                        NameTrack = t.NameTrack,
                                        Artist = t.Artist,
                                        Genre = t.Genre,
                                        PlaylistId = t.PlaylistId ?? 0
                                    }).ToList());
                myDataGrid.ItemsSource = tracks;

                pl = new ObservableCollection<PlaylistObserveViewModel>
                                    (
                                    context.Playlists.Select(t => new PlaylistObserveViewModel
                                    {
                                        NameList = t.NameList
                                    }).ToList());
                cmbPlaylist.ItemsSource = pl;
            }
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            using (EFContext context = new EFContext())
            {
                Track track = new Track
                {
                    Id = int.Parse(id_txtbx.Text),
                    NameTrack = nametrack_txtbx.Text,
                    Artist = artist_txtbx.Text,
                    Genre = genre_txtbx.Text
                };
                context.Tracks.Add(track);
                context.SaveChanges();
                tracks.Add(new TrackObserveViewModel
                {
                    Id = track.Id,
                    NameTrack = track.NameTrack,
                    Artist = track.Artist,
                    Genre = track.Genre
                });
            }
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            using (EFContext context = new EFContext())
            {
                if (myDataGrid.SelectedItem != null)
                {
                    var trackView = (myDataGrid.SelectedItem as TrackObserveViewModel);
                    var track = context.Tracks.SingleOrDefault(t => t.Id == trackView.Id);
                    if (track != null)
                    {
                        track.NameTrack = nametrack_txtbx.Text;
                        track.Artist = artist_txtbx.Text;
                        track.Genre = genre_txtbx.Text;
                        context.SaveChanges();
                        trackView.NameTrack = track.NameTrack;
                        trackView.Artist = track.Artist;
                        trackView.Genre = track.Genre;
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
                    var trackView = (myDataGrid.SelectedItem as TrackObserveViewModel);
                    var track = context.Tracks.SingleOrDefault(t => t.Id == trackView.Id);
                    if (track != null)
                    {
                        tracks.Remove(trackView);
                        context.Tracks.Remove(track);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            id_txtbx.Text = "";
            nametrack_txtbx.Text = "";
            artist_txtbx.Text = "";
            genre_txtbx.Text = "";
        }

        private void playlist_btn_Click(object sender, RoutedEventArgs e)
        {
            PlaylistForm pl = new PlaylistForm();
            pl.Show();
        }
    }
}
