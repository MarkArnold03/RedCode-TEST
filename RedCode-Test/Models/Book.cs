using System;
namespace RedCode_Test.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string Writer { get; set; } = null!;
		public DateTime PublishDate { get; set; }

    }
}

