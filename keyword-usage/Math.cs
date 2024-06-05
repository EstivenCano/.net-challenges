
public class Math
{
    public string sum(int[] numbers)
    {
        string operation = string.Join(" + ", numbers);
        string result = numbers.Sum().ToString();

        return $"{operation} = {result}";
    }
}