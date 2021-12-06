using HelixToolkit.Wpf;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace GarageApp.Controllers
{
    public static class UnitsController
    {
        public static BoxVisual3D CreateNewBox(double width, double height, double length, double X, double Y, double Z)
        {
            BoxVisual3D boxVisual3D = new BoxVisual3D();
            boxVisual3D.Width = width;
            boxVisual3D.Height = height;
            boxVisual3D.Length = length;
            boxVisual3D.Transform = new TranslateTransform3D(X, Y, Z);
            boxVisual3D.Fill = new BrushConverter().ConvertFromString("#FFD0D0D0") as Brush;

            return boxVisual3D;
        }

    }
}
