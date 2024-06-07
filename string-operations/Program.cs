// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

// Exercise 01

Console.WriteLine("Exercise 01:");

var summary = BenchmarkRunner.Run<Concatenator>();

/* --------------------------------------------------------- */
