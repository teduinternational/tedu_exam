using System.ComponentModel.DataAnnotations;

namespace Examination.Dtos.Categories
{
    public class CreateCategoryRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UrlPath { get; set; }
    }
}
