using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Customization
{
    public class ButtonGradientEffect : RoutingEffect
    {
        public ButtonGradientEffect(): base("abysoft.com.ButtonGradientEffect")
        {

        }

        public static readonly BindableProperty GradientColorProperty =
            BindableProperty.CreateAttached("GradientColor", typeof(Color), typeof(ButtonGradientEffect), Color.Green);

        public static void SetGradientColor(VisualElement visualElement, Color color)
        {
            visualElement.SetValue(GradientColorProperty, color);
        }

        public static Color GetGradientColor(VisualElement visualElement)
        {
            return (Color)visualElement.GetValue(GradientColorProperty);
        }
    }
}
