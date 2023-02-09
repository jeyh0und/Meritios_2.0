namespace OrtensLIA.Models.Domain
{
	public class User
	{
		public Guid id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNr { get; set; }
		public string School { get; set; }
		public string Education { get; set; }
		public string Location { get; set; }
	}
}
