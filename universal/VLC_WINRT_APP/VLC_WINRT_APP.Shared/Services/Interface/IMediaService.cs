﻿/**********************************************************************
 * VLC for WinRT
 **********************************************************************
 * Copyright © 2013-2014 VideoLAN and Authors
 *
 * Licensed under GPLv2+ and MPLv2
 * Refer to COPYING file of the official project for license
 **********************************************************************/

using libVLCX;
using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace VLC_WINRT_APP.Services.Interface
{
    public interface IMediaService
    {
        bool IsBackground { get; }

        /// <summary>
        /// Initialize passes either a SwapChainPanel for VLCService
        /// or the MediaElement itself from the XAML when using MediaFoundation
        /// </summary>
        /// <param name="panel"></param>
        void Initialize(object panel);

        Task SetMediaTransportControlsInfo(string artistName, string albumName, string trackName, string albumUri);

        Task SetMediaTransportControlsInfo(string title);
        /// <summary>
        /// Sets the path of the file to played.
        /// </summary>
        /// <param name="fileUri">The path of the file to be played.</param>
        Task SetMediaFile(string filePath, bool isAudioMedia, bool isStream, StorageFile file = null);

        void Play();
        void Pause();

        void Stop();
        void SetNullMediaPlayer();
        void FastForward();
        void Rewind();
        void SkipAhead();
        void SkipBack();

        float GetLength();

        int GetVolume();

        void SetVolume(int volume);

        void Trim();
        void SetSizeVideoPlayer(uint x, uint y);

        event EventHandler<libVLCX.MediaState> StatusChanged;
        event TimeChanged TimeChanged;

        TaskCompletionSource<bool> ContinueIndexing { get; set; }
        TaskCompletionSource<bool> PlayerInstanceReady { get; set; } 
    }
}
