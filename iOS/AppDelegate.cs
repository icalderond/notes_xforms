﻿using System;
using System.Collections.Generic;
using System.Linq;
using SuaveControls.FloatingActionButton.iOS.Renderers;

using Foundation;
using UIKit;

namespace notes_xform.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
            Xamarin.Calabash.Start();
#endif
            //Corcav.Behaviors.Infrastructure.Init();
            //FloatingActionButtonRenderer.InitRenderer();
            FloatingActionButtonRenderer.InitRenderer();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}
