using Day2.Models;

namespace Day2.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        ITIContext db;

        public DepartmentRepository(ITIContext context)
        {
            db = context;
        }

        public List<Department> getAll()
        {
            return db.Departments.ToList(); 
        }

        public Department getById(int id)
        {
            return db.Departments.FirstOrDefault(n => n.id == id);  
        }

        public void add(Department newDept)
        {
            db.Departments.Add(newDept);
            db.SaveChanges();
        }

        public void update(int id, Department newDept)
        {
            Department oldDept = db.Departments.FirstOrDefault(n => n.id == id);
            oldDept.name = newDept.name;
            oldDept.manager = newDept.manager;

            db.SaveChanges();
        }

        public void delete(int id)
        {
            Department dept = db.Departments.FirstOrDefault(n => n.id == id);
            db.Departments.Remove(dept);
            db.SaveChanges();
        }
    }
}
