using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using CoreAnimation;

namespace Customization.iOS
{
    public static class Gradient
    {
        public static CAGradientLayer GetGradientLayer(CGColor topColor, CGColor bottomColor, nfloat width, nfloat height)
        {
            var gradientLayer = new CAGradientLayer();
            gradientLayer.Frame = new CGRect(0, 0, width, height);
            gradientLayer.Colors = new CGColor[] { topColor, bottomColor };
            gradientLayer.StartPoint = new CGPoint(0, 0);
            gradientLayer.EndPoint = new CGPoint(0, 1);
            return gradientLayer;
        }
    }
}