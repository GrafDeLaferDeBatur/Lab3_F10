using System;
using System.Collections.Generic;
using System.IO;
using Serilog;
using Serilog.Events;

public class TriangleCalculator
{
    private static readonly ILogger Logger = new LoggerConfiguration()
        .WriteTo.File("C:\\Users\\asb20\\source\\repos\\test_lab2\\test_lab2\\logs.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();
    public static string? ReadLine(string question)
    {
        Console.WriteLine(question);
        return Console.ReadLine();
    }

    public static (string, List<(int, int)>) CalculateTriangleTypeAndCoordinates(string sideA, string sideB, string sideC)
    {
        List<(int, int)> coordinates = new List<(int, int)>();
        string triangleType = "";

        try
        {
            float a = float.Parse(sideA);
            float b = float.Parse(sideB);
            float c = float.Parse(sideC);

            // Add a check to ensure that the input values are not greater than 100
            if (a <= 100 && b <= 100 && c <= 100)
            {
                // Check if the input represents a valid triangle
                if (a + b > c && a + c > b && b + c > a)
                {
                    if (a == b && b == c)
                    {
                        triangleType = "равносторонний";
                    }
                    else if (a == b || b == c || a == c)
                    {
                        triangleType = "равнобедренный";
                    }
                    else
                    {
                        triangleType = "разносторонний";
                    }

                    // Calculate scaled coordinates for a 100x100 px field
                    coordinates.Add(((int)(a * 100), 50)); // Centering horizontally
                    coordinates.Add(((int)(c * 100), 0));  // Vertex at the top
                    coordinates.Add(((int)(b * 100), 100)); // Vertex at the bottom
                }
                else
                {
                    triangleType = "не треугольник"; // Not a triangle
                    coordinates.Add((-1, -1));
                    coordinates.Add((-1, -1));
                    coordinates.Add((-1, -1));
                }
            }
            else
            {
                triangleType = "недопустимые значения"; // Values exceed the limit
                coordinates.Add((-3, -3));
                coordinates.Add((-3, -3));
                coordinates.Add((-3, -3));
            }
        }
        catch (FormatException)
        {
            // Handle invalid input
            triangleType = "";
            coordinates.Add((-2, -2));
            coordinates.Add((-2, -2));
            coordinates.Add((-2, -2));
        }

        LogRequest(DateTime.Now, sideA, sideB, sideC, triangleType, coordinates);
        return (triangleType, coordinates);
    }


    public static void LogRequest(DateTime timestamp, string sideA, string sideB, string sideC, string triangleType, List<(int, int)> coordinates)
    {
        Logger.Information("Timestamp: {Timestamp}", timestamp);
        Logger.Information("Input Sides: A={SideA}, B={SideB}, C={SideC}", sideA, sideB, sideC);
        Logger.Information("Triangle Type: {TriangleType}", triangleType);
        Logger.Information("Coordinates: A({A1}, {A2}), B({B1}, {B2}), C({C1}, {C2})",
            coordinates[0].Item1, coordinates[0].Item2, coordinates[1].Item1, coordinates[1].Item2, coordinates[2].Item1, coordinates[2].Item2);
    }
}