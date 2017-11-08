using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Customization.iOS;
using Xamarin.Forms.Platform.iOS;
using CoreAnimation;
using System.ComponentModel;
using Customization;

[assembly: ResolutionGroupName("abysoft.com")]
[assembly: ExportEffect(typeof(IosButtonGradientEffect), "ButtonGradientEffect")]
namespace Customization.iOS
{
    public class IosButtonGradientEffect : PlatformEffect
    {
        CAGradientLayer gradientLayer;
        protected override void OnAttached()
        {
            if (Element is Button == false)
            {
                return;
            }
            CreateGradient();
        }

        private void CreateGradient()
        {
            gradientLayer?.RemoveFromSuperLayer();

            var button = Element as Button;
            var uiButton = Control as UIButton;

            if (uiButton.Frame.Width == 0 || uiButton.Frame.Height == 0)
            {
                return;
            }

            var topColor = button.BackgroundColor;
            var bottomColor =  ButtonGradientEffect.GetGradientColor(button);
            gradientLayer = Gradient.GetGradientLayer(topColor.ToCGColor(), bottomColor.ToCGColor(), uiButton.Frame.Width, uiButton.Frame.Height);
            Control.Layer.InsertSublayer(gradientLayer, 0);
        }

        protected override void OnDetached()
        {
            gradientLayer?.RemoveFromSuperLayer();
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            if (Element is Button == false)
            {
                return;
            }
            if (args.PropertyName == "GradientColor")
            {
                CreateGradient();
            }
        }
    }
}