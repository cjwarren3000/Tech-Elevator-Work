using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IStudentDAO
    {
        List<Student> GetStudents();
        Student GetStudent(int id);
        void DeleteStudent(int id);
        Student CreateStudent(Student student);
        void UpdateStudent(Student student);
    }
}