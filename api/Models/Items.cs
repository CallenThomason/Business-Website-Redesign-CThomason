

namespace api.Models
{
    public class Items : BaseEntity
    {
      
       public string Name {get; set;} = string.Empty; 
       public int Category_id {get; set;}  
        public int Price {get; set;}
        public string Description {get; set;} = string.Empty; 
        public string Image_url{get; set;} = string.Empty; 
        public string Tag {get; set;} = string.Empty; 

    }
}