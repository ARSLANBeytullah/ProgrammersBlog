using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Entities.Abstract
{
    //Base değerlerin diğer sınıflarda ddeğişikliğe uğramasını isteyebiliriz. O yüzden abstract ile imzaladık. 
    //Abstract sayesinde override işlemi yapabiliriz. Override edilmiş özellikleri de virtual olarak tanımlamamız gerekiyor
    
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now; //Oluşturma tarihi değiştirilebileceğindenc virtual olarak işaretledim.
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual string ModifiedByName { get; set; } = "Admin";
        public virtual string Note { get; set; }
    }
}
