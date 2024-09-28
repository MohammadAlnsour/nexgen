namespace nexgen.Application.Contracts.DTOs
{
    public class ChapterResposeDTO
    {
        public string ChapterName { get; set; }
        public List<LessonResponseDTO> Lessons { get; set; }
    }
}