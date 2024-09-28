using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Application.Contracts.DTOs
{
    public class CourseResponseDTO
    {
        public string CourseName { get; set; }
        public string CourseImage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string InstructorName { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ChapterResposeDTO> Chapters { get; set; }
    }
}
