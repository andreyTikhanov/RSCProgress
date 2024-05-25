namespace RSCProgerss.Model.DBModel
{
    public class DBModel
    {
        public static bool CreateEmployee(Employee employee)
        {
            if (employee == null) return false;
            using (FactoryContext db = new FactoryContext())
            {
                var newEmployee = db.Employees.FirstOrDefault(e => e.Id == employee.Id);
                if (newEmployee == null)
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public static bool DeleteEmployee(Employee employee)
        {
            using (FactoryContext db = new FactoryContext())
            {
                if (employee == null) return false;
                var deleteEmployee = db.Employees.FirstOrDefault(e => e.Id == employee.Id);
                if (deleteEmployee != null)
                {
                    db.Employees.Remove(deleteEmployee);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool RenewEmployee(Employee employee, string? firstName = null, string?
                                         secondName = null, DateTime? experiance = null, string?
                                         password = null, string? role = null, byte[]? photo = null, int? cat=0)
        {
            if (employee == null) return false;
            if (firstName != null) employee.FirstName = firstName;
            if (secondName != null) employee.SecondName = secondName;
            if (experiance != null) employee.Experiance = experiance;
            if (password != null) employee.Password = password;
            if (role != null) employee.Role = role;
            if (photo != null) employee.Photo = photo;
            if(employee is Worker worker && cat.HasValue)
            {
                worker.Category = cat.Value;
            }
            using (FactoryContext db = new FactoryContext())
            {
                db.Update(employee);
                db.SaveChanges();
            }

        }
    }
}
