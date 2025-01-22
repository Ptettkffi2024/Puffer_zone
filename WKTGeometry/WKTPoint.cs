using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Puffer_Zone.WKFServices;

namespace Puffer_Zone.WKFGeometry;

public class WKTPoint
{
    private double x { get; }
    private double y { get; }

    private const int SEGMENTS = 36;

    public WKTPoint(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public static WKTPoint CreateFromInput()
    {
        double pointA = WKTInputHandler.ReadUserInput("Reading coordinate X:");
        double pointB = WKTInputHandler.ReadUserInput("Reading coordinate Y:");
        
        return new WKTPoint(pointA, pointB);
    }

    public string CalculateBuffer(double radius)
    {
        StringBuilder polygonBuilder = new StringBuilder("POLYGON ((");
        
        
        double angleStep = 360.0 / SEGMENTS; 
        for (int i = 0; i <= SEGMENTS; i++) 
        {
            double angle = i * angleStep * Math.PI / 180.0; 
            double newX = this.x + radius * Math.Cos(angle); 
            double newY = this.y + radius * Math.Sin(angle); 
            string xString = newX.ToString(CultureInfo.InvariantCulture);
            string yString = newY.ToString(CultureInfo.InvariantCulture);
            polygonBuilder.Append($"{xString} {yString}, ");
          
        }

        
        polygonBuilder.Remove(polygonBuilder.Length - 2, 2);
        polygonBuilder.Append("))");
        
        return polygonBuilder.ToString();
    }

}