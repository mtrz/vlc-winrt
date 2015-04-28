﻿/**********************************************************************
 * VLC for WinRT
 **********************************************************************
 * Copyright © 2013-2014 VideoLAN and Authors
 *
 * Licensed under GPLv2+ and MPLv2
 * Refer to COPYING file of the official project for license
 **********************************************************************/
using Windows.Graphics.Display;
using Windows.Media;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Autofac;
using VLC_WinRT.Helpers;
using VLC_WinRT.Services.RunTime;
using VLC_WinRT.ViewModels;
using Windows.UI.ViewManagement;

namespace VLC_WinRT.Views.MainPages
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private void SwapPanelLoaded(object sender, RoutedEventArgs e)
        {
            App.Container.Resolve<VLCService>().Initialize(SwapChainPanel);
        }
                
        private void SplitShell_FlyoutCloseRequested(object sender, System.EventArgs e)
        {
            Locator.NavigationService.GoBack_HideFlyout();
        }
    }
}