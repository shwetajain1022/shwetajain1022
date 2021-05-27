using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatternMatching.DTO
{
    public class PatternMatchDTO: IValidatableObject
    {
        [Required]
        public string SubText { get; set; }
        [Required]
        public string Text { get; set; }
        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Text.Length<SubText.Length)
            {
                yield return new ValidationResult("Text string length cannot be less than SubText string length.");
            }
        }
    }
}