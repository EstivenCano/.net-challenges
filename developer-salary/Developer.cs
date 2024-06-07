namespace developer_salary
{    
    public enum DeveloperType
    {
        Junior,
        Intermediate,
        Senior,
        Lead
    }

    public class Developer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DeveloperType Type { get; set; }
        public int WorkedHours { get; set; }
        public decimal SalaryByHour { get; set; }
        public decimal TotalSalary { get; set; }
    }
}

