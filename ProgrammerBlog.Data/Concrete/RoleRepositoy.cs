using Microsoft.EntityFrameworkCore;
using ProgrammerBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerBlog.Data.Concrete
{
    public class RoleRepositoy : EfEntityRepositoryBase<Role>, IRoleRepository
    {
        public RoleRepositoy(DbContext context) : base(context)
        {
        }
    }
}
