using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Shared.Questions
{
    public class AnswerDto
    {
        public string Id { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public Guid ClientId { get; set; } = Guid.NewGuid();
    }
}
