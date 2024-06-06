using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
public class Concatenator
{
    [Benchmark]
    [Arguments("Celeste", "Chase", "Korah", "Dalila")]    
    public string WithLiterals(string name1, string name2, string name3, string name4)
    {
        return "Hello " + name1 + " " + name2 + " " + name3 + " " + name4;
    }

    [Benchmark]
    [Arguments("Celeste", "Chase", "Korah", "Dalila")]
    public string WithInterpolation(string name1, string name2, string name3, string name4)
    {
        return $"Hello {name1} {name2} {name3} {name4}";
    }

    [Benchmark]
    [Arguments("Celeste", "Chase", "Korah", "Dalila")]
    public string WithConcat(string name1, string name2, string name3, string name4)
    {  
        return string.Concat("Hello ", name1," ", name2," ", name3," ", name4);
    }

    [Benchmark]
    [Arguments("Celeste", "Chase", "Korah", "Dalila")]
    public string WithJoin(string name1, string name2, string name3, string name4)
    {
        string[] names = ["Hello", name1, name2, name3, name4];
        return string.Join(" ", names);
    }

    [Benchmark]
    [Arguments("Celeste", "Chase", "Korah", "Dalila")]
    public string WithLINQ(string name1, string name2, string name3, string name4)
    {
        string[] names = ["Hello", name1, name2, name3, name4];
        return names.Aggregate((partialPhrase, word) => $"{partialPhrase} {word}");

    }
}

