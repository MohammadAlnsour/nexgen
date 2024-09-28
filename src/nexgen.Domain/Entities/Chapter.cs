namespace nexgen.Domain.Entities
{
    public class Chapter : BaseDbEntity
    {
        public int Id { get; private set; }
        public string ChapterName { get; private set; }

        public int CourseId { get; private set; }
        public Course Course { get; private set; }

        public List<Lesson> Lessons { get; set; }

        public Chapter SetBasic(string chapterName)
        {
            this.ChapterName = chapterName;
            return this;
        }

        public Chapter SetLessons(List<Lesson> lessons)
        {
            this.Lessons = lessons;
            return this;
        }

        public Chapter SetCourse(Course course , int courseId)
        {
            this.CourseId = courseId;
            this.Course = course;
            return this;
        }

    }
}