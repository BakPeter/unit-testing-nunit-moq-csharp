﻿using Microsoft.EntityFrameworkCore;
using TestNinja.Interfaces.Mocking;

namespace TestNinja.Services.Mocking;

public class EmployeeStorage : IEmployeeStorage
{
    private EmployeeContext _db;

    public EmployeeStorage()
    {
        _db = new EmployeeContext();
    }
    
    public void DeleteEmployee(int id)
    {
        var employee = _db.Employees.Find(id);
        _db.Employees.Remove(employee);
        _db.SaveChanges();
    }
}
public class EmployeeContext
{
    public DbSet<Employee> Employees { get; set; }

    public void SaveChanges()
    {
    }
}

public class Employee
{
}