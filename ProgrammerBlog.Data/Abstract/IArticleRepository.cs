using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerBlog.Data.Abstract
{
    public interface IArticleRepository : IEntityRepository<Article> //Article'a özel methodların imzalarını burada tanımlayabiliriz. Onun dışında ki ortak method interfaceleri zaten IEntityRepository'den gelmektedir.
    {
       
    }
}
