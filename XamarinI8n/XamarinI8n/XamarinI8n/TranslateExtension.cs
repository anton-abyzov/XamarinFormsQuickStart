﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinI8n
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private readonly CultureInfo ci;
        const string ResourceId = "XamarinI8n.AppResources";

        public TranslateExtension()
        {
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                //ci = DependencyService.Get<ILocalize> ().GetCurrentCultureInfo ();  // to get it from the phone
                ci = AppResources.Culture;

            }
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(ResourceId
                          , typeof(TranslateExtension).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                   String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                   "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}
