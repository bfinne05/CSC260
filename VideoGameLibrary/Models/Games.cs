using VideoGameLibrary.Validators;
using System.ComponentModel.DataAnnotations;

namespace VideoGameLibrary.Models
{
	[VideoGame]
	public class Games
	{

		[Key]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public string Platform { get; set; }
		[Required]
		public string Genre { get; set; }
		[Required]
		public int Year { get; set; }
		[Required]
		public string ESRB { get; set; }
		public DateTime? LoanDate { get; set; } = null;
		public string? Image { get; set; }
		public string? LoanedTo { get; set; } = string.Empty;


		public Games() { }
		public Games(string title, string Platform, string genre, int year, string esrb, DateTime? loanDate, string? loanedTo, string? image)
		{
			this.Title = title;
			this.Platform = Platform;
			this.Genre= genre;
			this.Year= year;
			this.ESRB= esrb;
			this.LoanDate= loanDate;
			this.LoanedTo= loanedTo;
			this.Image= image;
		}
		public override string ToString()
		{
			return $"{Title} - {Genre} - {Year} - {ESRB} - {LoanDate} - {LoanedTo} - {Image}";
		}
	}
}

