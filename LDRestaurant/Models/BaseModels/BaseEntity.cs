namespace LDRestaurant.Models.BaseModels
{
    public abstract class BaseEntity 
    {
        public Guid Id { get; set; }//Generate Unique Identificator 3f4a89f2-5c8b-4d6e-90e2-b5f78a65f1c3
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }//remove permanent -  delete temporarily
        public bool isDeleted { get; set; }//false olanda silinmir, true olanda muveqqeti silinib demekdir (delete).
    }
}
