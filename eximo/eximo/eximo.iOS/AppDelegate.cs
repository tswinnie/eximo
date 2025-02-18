﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarouselView.FormsPlugin.iOS;
using FFImageLoading.Forms.Platform;
using FFImageLoading.Svg.Forms;
using Foundation;
using UIKit;
using SQLitePCL;

namespace eximo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Batteries_V2.Init();

            global::Xamarin.Forms.Forms.Init();
            CarouselViewRenderer.Init();
            CachedImageRenderer.Init();
            var ignore = typeof(SvgCachedImage);
            
            var libPath = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),"..", "Library", "data");
            
            if (!Directory.Exists(libPath))
            {
                Directory.CreateDirectory(libPath);
            }
            
            var dbPath = Path.Combine(libPath, "eximo.sqlite");
            
            LoadApplication(new App(dbPath));

            return base.FinishedLaunching(app, options);
        }
    }
}
