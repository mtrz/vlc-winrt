﻿using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using VLC_WINRT.Common;
using VLC_WINRT.Utility.Helpers;
using VLC_WINRT.Utility.Services.RunTime;
using VLC_WINRT.ViewModels;
using VLC_WINRT.ViewModels.MainPage;
using VLC_WINRT.Views;

namespace VLC_WINRT.Utility.Commands
{
    public class PlayTrackCommand : AlwaysExecutableCommand
    {
        public async override void Execute(object parameter)
        {
            MusicLibraryViewModel.TrackItem track = parameter as MusicLibraryViewModel.TrackItem;
            Locator.MusicPlayerVM.TrackCollection.ResetCollection();
            Locator.MusicPlayerVM.TrackCollection.AddTrack(track);
            Locator.MusicPlayerVM.PlayNext();

            var frame = App.ApplicationFrame;
            var page = frame.Content as Views.MainPage;
            if (page != null)
            {
                var sB = page.Resources["FadeOutPage"] as Storyboard;
                if (sB != null)
                {
                    await sB.BeginAsync();
                    NavigationService.NavigateTo(typeof(PlayMusic));
                }
            }
        }
    }
}
