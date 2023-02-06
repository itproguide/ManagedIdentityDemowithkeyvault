namespace ManagedIdentityDemowithkeyvault.Model
{
    public class profile
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? job { get; set; }
        [Column(TypeName = "nchar(10)")]
        public string? mobile { get; set; }
    }
}
