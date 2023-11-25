using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_lab2.Models;

namespace test_lab2.Controllers
{
    public class Controller
    {
        private static string sideA, sideB, sideC;
        public static void toDo(string action)
        {
            if (action == "delete")
            {
                var reader = Triangle.all();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"sideA: {reader["sideA"]}; sideB: {reader["sideB"]}; sideC: {reader["sideC"]}; type: {reader["type"]}; error: {reader["message_error"]}; ");
                    }
                    Console.WriteLine("Enter sides for deleting triangle");
                    sideA = TriangleCalculator.ReadLine("Enter side A length: ");
                    sideB = TriangleCalculator.ReadLine("Enter side B length: ");
                    sideC = TriangleCalculator.ReadLine("Enter side C length: ");
                    if (Triangle.deleteBySides(sideA, sideB, sideC))
                    {
                        Console.WriteLine("Sides was deleted successfuly");
                    }
                    else
                    {
                        Console.WriteLine("Sides was not deleted successfuly");
                    }
                }
                else
                {
                    Console.WriteLine("Table is empty or something wrong was happened");
                }
            }
            else if (action == "update")
            {
                var reader = Triangle.all();
                if (reader != null && reader.HasRows)
                {
                    Console.WriteLine("List of sides: ");
                    Console.WriteLine("");
                    while (reader.Read())
                    {
                        Console.WriteLine($"sideA: {reader["sideA"]}; sideB: {reader["sideB"]}; sideC: {reader["sideC"]}; type: {reader["type"]}; error: {reader["message_error"]}; ");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Enter sides for updating triangle");
                    sideA = TriangleCalculator.ReadLine("Enter side A length: ");
                    sideB = TriangleCalculator.ReadLine("Enter side B length: ");
                    sideC = TriangleCalculator.ReadLine("Enter side C length: ");
                    string _sideA = TriangleCalculator.ReadLine("Enter new side A length: ");
                    string _sideB = TriangleCalculator.ReadLine("Enter new side B length: ");
                    string _sideC = TriangleCalculator.ReadLine("Enter new side C length: ");
                    if (Triangle.updateBySides(sideA, sideB, sideC, _sideA, _sideB, _sideC))
                    {
                        Console.WriteLine("Sides was updated successfuly");
                    }
                    else
                    {
                        Console.WriteLine("Sides was not updated successfuly");
                    }
                }
                else
                {
                    Console.WriteLine("Table is empty or something wrong was happened");
                }
            }
            else if (action == "add")
            {
                sideA = TriangleCalculator.ReadLine("Enter side A length: ");
                sideB = TriangleCalculator.ReadLine("Enter side B length: ");
                sideC = TriangleCalculator.ReadLine("Enter side C length: ");
                (string triangleType, List<(int, int)> coordinates) = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

                if (triangleType != "")
                {
                    Console.WriteLine($"Triangle Type: {triangleType}");
                    Console.WriteLine($"Coordinates: A({coordinates[0].Item1}, {coordinates[0].Item2}), " +
                        $"B({coordinates[1].Item1}, {coordinates[1].Item2}), " +
                        $"C({coordinates[2].Item1}, {coordinates[2].Item2})");
                    if (triangleType == "не треугольник")
                    {
                        if (Triangle.add(sideA, sideB, sideC, "", "Фигура - не треугольник") != null ? true : false)
                        {
                            Console.WriteLine("Sides was added with error");
                        }
                        else
                        {
                            Console.WriteLine("Sides was not added with error");
                        }
                    }
                    else if (triangleType == "недопустимые значения")
                    {
                        if (Triangle.add(sideA, sideB, sideC, "", "Введены недопустимые значения") != null ? true : false)
                        {
                            Console.WriteLine("Sides was added with error");
                        }
                        else
                        {
                            Console.WriteLine("Sides was not added with error");
                        }
                    }
                    else if (triangleType == "")
                    {
                        if (Triangle.add(sideA, sideB, sideC, "", "Введены некорректные значения") != null ? true : false)
                        {
                            Console.WriteLine("Sides was added with error");
                        }
                        else
                        {
                            Console.WriteLine("Sides was not added with error");
                        }
                    }
                    else
                    {
                        if (Triangle.add(sideA, sideB, sideC, triangleType) != null ? true : false)
                        {
                            Console.WriteLine("Sides was added successfuly");
                        }
                        else
                        {
                            Console.WriteLine("Sides was not added successfuly");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Check your data");
                }
            }
            else
            {
                Console.WriteLine("Check your action");
            }
        }
    }
}
