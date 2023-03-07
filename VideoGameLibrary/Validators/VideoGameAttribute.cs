using System.ComponentModel.DataAnnotations;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Validators
{
    public class VideoGameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var game = (Games)validationContext.ObjectInstance;
            if(game.Title == null)
            {
                return new ValidationResult("You must enter a title for the game");
            }

            if(game.Year == null)
            {
                return new ValidationResult("You must enter a year");
            }
            if (game.Year >= 1958 && game.Year < 2024)
            {}
            else
            {
                return new ValidationResult("Video games weren't created at that time...");
            }

            if(game.ESRB == null)
            {
                return new ValidationResult("Game must have an esrb rating");
            }

            if(game.Platform == null)
            {
                return new ValidationResult("The game must have a platform");
            }


            //return base.IsValid(value, validationContext);
            return ValidationResult.Success;
        }
    }
}