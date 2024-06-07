using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developer_salary
{
    internal class FileReader
    {
        public static List<Developer> ReadDevelopersFromCsv(string filePath)
        {
            var developers = new List<Developer>();
            using (var reader = new StreamReader(filePath))
            {
                var headerLine = reader.ReadLine();

                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var values = line.Split(',');                    
                    var developer = new Developer
                    {
                        Id = int.Parse(values[0]),
                        Name = values[1],
                        Type = (DeveloperType)Enum.Parse(typeof(DeveloperType), values[2]),
                        WorkedHours = int.Parse(values[3]),
                        SalaryByHour = decimal.Parse(values[4])
                    };
                    developers.Add(developer);
                }
            }
            return developers;
        }
    }
}
