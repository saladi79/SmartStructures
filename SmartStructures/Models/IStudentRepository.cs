﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartStructures.Models
{
    public interface IStudentRepository
    {
        Student GetStudent(int Id);
        IEnumerable<Student> GetAllStudents();
        Student Add(Student student);
        Student Update(Student studentChanges);
        Student Delete(int id);
    }
}
