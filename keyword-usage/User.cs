using System.Reflection;

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public User(string name, int age, string email)
    {
        Name = name;
        Age = age;
        Email = email;
    }

    public void logUser()
    {
        Type userType = typeof(User);        

        // Get the properties of the User class
        PropertyInfo[] properties = userType.GetProperties();

        // Print each property name and type
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine($"{property.Name}: {property.GetValue(this)}");
        }        
    }
}