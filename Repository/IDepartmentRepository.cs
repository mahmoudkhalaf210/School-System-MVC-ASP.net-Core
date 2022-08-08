using Day2.Models;

namespace Day2.Repository
{
    public interface IDepartmentRepository
    {
        public List<Department> getAll();

        public Department getById(int id);

        public void add(Department newDept);

        public void update(int id, Department newDept);

        public void delete(int id);
       
    }
}
