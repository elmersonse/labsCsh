﻿using System.Security.Cryptography;

namespace Lab2;

public class Worker : IToString
{
    public string Name { get; set; }
    private static float _baseSalary = 10; 
    private float _salary;
    
    public float Salary
    {
        get => _salary;
        set
        {
            if (value < 0)
            {
                _salary = 0;
            }
            else
            {
                _salary = value;
            }
        }
    }

    public Worker()
    {
        Name = "";
        _salary = 0;
    }

    public Worker(string name, float salary)
    {
        Name = name;
        _salary = salary;
    }

    public float GetBaseSalary()
    {
        return _baseSalary;
    }

    public override string ToString()
    {
        return Name + ";" + _salary;
    }
}