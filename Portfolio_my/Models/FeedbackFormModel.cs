using System.ComponentModel.DataAnnotations;

namespace Portfolio_my.Models
{
    public class FeedbackFormModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
