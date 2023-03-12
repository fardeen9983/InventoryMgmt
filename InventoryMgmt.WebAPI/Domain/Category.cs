namespace InvnetoryMgmt.WebApi.Domain
{
    public class Category
    {
        public Category(int id, string name, DateTime createdAt, string description = "", bool isActive = true,  int createdBy = 1)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}
