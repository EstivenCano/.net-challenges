// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

// Exercise 01

Console.WriteLine("Exercise 01:");
//string[] names = ["one", "two", "three"];

//string literalsResult = Concatenator.WithLiterals("Celeste", "Chase", "Korah", "Dalila");
//string interpolationResult = Concatenator.WithInterpolation("Celeste", "Chase", "Korah", "Dalila");
//string concatResult = Concatenator.WithConcat("Celeste", "Chase", "Korah", "Dalila");
//string joinResult = Concatenator.WithJoin("Celeste", "Chase", "Korah", "Dalila");
//string lineQResult = Concatenator.WithLINQ("Celeste", "Chase", "Korah", "Dalila");

//Console.WriteLine(literalsResult);
//Console.WriteLine(interpolationResult);
//Console.WriteLine(concatResult);
//Console.WriteLine(joinResult);
//Console.WriteLine(lineQResult);

var summary = BenchmarkRunner.Run<Concatenator>();

/* --------------------------------------------------------- */
