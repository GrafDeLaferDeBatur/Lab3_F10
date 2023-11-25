//using test_lab2.Models;

//string sideA, sideB, sideC;

//sideA = TriangleCalculator.ReadLine("Enter side A length: ");
//sideB = TriangleCalculator.ReadLine("Enter side B length: ");
//sideC = TriangleCalculator.ReadLine("Enter side C length: ");

//(string triangleType, List<(int, int)> coordinates) = TriangleCalculator.CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);

//Console.WriteLine($"Triangle Type: {triangleType}");
//Console.WriteLine($"Coordinates: A({coordinates[0].Item1}, {coordinates[0].Item2}), " +
//    $"B({coordinates[1].Item1}, {coordinates[1].Item2}), " +
//    $"C({coordinates[2].Item1}, {coordinates[2].Item2})");

using test_lab2.Models;
using test_lab2.Controllers;

string action = TriangleCalculator.ReadLine("What to do?");
Controller.toDo(action);

