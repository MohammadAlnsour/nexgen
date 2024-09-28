namespace nexgen.Domain.Entities
{
    public class Course : BaseDbEntity, IAggregateRoot
    {
        public int Id { get; private set; }
        public string CourseName { get; private set; }
        public string CourseImage { get; private set; }
        public DateTime CourseStartDate { get; private set; }
        public DateTime CourseEndDate { get; private set; }
        public int InstructorId { get; private set; }
        public Instructor Instructor { get; private set; }

        public List<Chapter> Chapters { get; private set; }

        public Course SetBasic(string courseName, string courseImage, DateTime courseStartdate, DateTime courseEnddate)
        {
            this.CourseName = courseName;
            this.CourseImage = courseImage;
            this.CourseStartDate = courseStartdate;
            this.CourseEndDate = courseEnddate;
            return this;
        }

        public Course SetInstructor(Instructor instructor, int instructorId)
        {
            this.InstructorId = instructorId;
            this.Instructor = instructor;
            return this;
        }

        public Course SetChapters(List<Chapter> chapters)
        {
            this.Chapters = chapters;
            return this;
        }

        public Course SetChapterLessons(Chapter chapter, List<Lesson> lessons)
        {
            chapter.SetLessons(lessons);
            this.Chapters.Add(chapter);
            return this;
        }

    }
}
