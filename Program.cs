// See https://aka.ms/new-console-template for more information

using System;
using Puffer_Zone;
using Puffer_Zone.WKFGeometry;
using Puffer_Zone.WKFServices;

Console.WriteLine("Reading a Point...");

WKTPoint point = WKTPoint.CreateFromInput();

Console.WriteLine(point.CalculateBuffer(WKTInputHandler.ReadRadius()));
