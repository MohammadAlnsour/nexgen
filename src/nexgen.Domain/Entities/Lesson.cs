namespace nexgen.Domain.Entities
{
    public class Lesson : BaseDbEntity
    {
        public int Id { get; private set; }

        public int CourseId { get; private set; }
        public Course Course { get; private set; }


        public int ChapterId { get; private set; }
        public Chapter Chapter { get; private set; }

        public string LessonName { get; private set; }
        public string VideoPath { get; private set; }
        public string VideoDuration { get; private set; }
        public string VideoType { get; private set; }

        public Lesson SetBasic(string name, string vidPath, string vidDuration, string vidType)
        {
            this.LessonName = name;
            this.VideoPath = vidPath;
            this.VideoDuration = vidDuration;
            this.VideoType = vidType;
            return this;
        }

        public Lesson SetChapter(int chapterId, Chapter chapter)
        {
            this.ChapterId = chapterId;
            this.Chapter = chapter;
            return this;
        }

        public Lesson SetCourse(int courseId, Course course)
        {
            this.CourseId = courseId;
            this.Course = course;
            return this;
        }

    }
}