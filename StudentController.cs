using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();

        public IActionResult Add()
        {
            return View(new Student());
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            student.Id = Guid.NewGuid();
            students.Add(student);
            return RedirectToAction("View");
        }

        public IActionResult View()
        {
            return View(students);
        }

        public IActionResult Edit(Guid id)
        {
            var student = students.Find(s => s.Id == id);
            return View("Edit", student);
        }

        [HttpPost]
        public IActionResult Edit(Student updatedStudent)
        {
            var existingStudent = students.Find(s => s.Id == updatedStudent.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = updatedStudent.Name;
                existingStudent.Age = updatedStudent.Age;
                existingStudent.Email = updatedStudent.Email;
                existingStudent.PhoneNumber = updatedStudent.PhoneNumber;
                existingStudent.Address = updatedStudent.Address;
            }

            return RedirectToAction("View");
        }

        public IActionResult Delete(Guid id)
        {
            var student = students.Find(s => s.Id == id);
            students.Remove(student);
            return RedirectToAction("View");
        }
    }
}