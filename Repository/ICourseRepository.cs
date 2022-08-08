using Day2.Models;

namespace Day2.Repository
{
    public interface ICourseRepository
    {
        public Guid id { get; set; }

        public List<Course> getAll();

        public Course getById(int id);

        public void add(Course newCrs);

        public void update(int id, Course newCrs);

        public void delete(int id);
    }
}
