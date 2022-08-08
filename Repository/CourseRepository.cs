using Day2.Models;

namespace Day2.Repository
{
    public class CourseRepository: ICourseRepository
    {
        ITIContext db;

        public CourseRepository(ITIContext context)
        {
            db = context;
        }

        public Guid id { get; set; }

        public CourseRepository()
        {
            id = Guid.NewGuid();
        }

        public List<Course> getAll()
        {
            return  db.Courses.ToList();
        }
        public Course getById(int id)
        {
            return db.Courses.FirstOrDefault(n => n.id == id);
        }

        public void add(Course newCrs)
        {
            db.Courses.Add(newCrs);
            db.SaveChanges();
        }

        public void update(int id, Course newCrs)
        {
            Course oldCrs = db.Courses.FirstOrDefault(n => n.id == id);

            oldCrs.name = newCrs.name;
            oldCrs.degree = newCrs.degree;
            oldCrs.minDegree = newCrs.minDegree;
            oldCrs.dept_id = newCrs.dept_id;

            db.SaveChanges();
        }

        public void delete(int id)
        {
            Course crs = db.Courses.FirstOrDefault(n => n.id == id);
            db.Courses.Remove(crs);
            db.SaveChanges();
        }
    }
}
