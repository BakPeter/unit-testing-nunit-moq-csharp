﻿using TestNinja.Interfaces.Mocking;

namespace TestNinja.Services.Mocking;

public class EmployeeController
{
    private readonly IEmployeeStorage _employeeStorage;
    
    public EmployeeController(IEmployeeStorage employeeStorage)
    {
        _employeeStorage = employeeStorage;
    }

    public ActionResult DeleteEmployee(int id)
    {
        _employeeStorage.DeleteEmployee(id);
        return RedirectToAction("Employees");
    }

    private ActionResult RedirectToAction(string employees)
    {
        return new RedirectResult();
    }
}

public class ActionResult { }
 
public class RedirectResult : ActionResult { }
    