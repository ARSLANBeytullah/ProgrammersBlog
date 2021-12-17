using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerBlog.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable //Unit of work tasarım deseni sayesinde bütün repositoryilerimizi tek bir noktadan yönetebiliriz.
    {
        IArticleRepository Articles { get; } //unitofwork.Articles diyerek Article'a erişebiliyor olacağız.
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; } //_unitOfWork.Categories.AddAsync(); bu şekilde kullancağız.


        //_unitOfWork.Categories.AddAsync(category);
        //_unitOfWork.Users.AddAsync(user);
        //_unitOfWork.SaveAsync();           bu şekilde kategori ve kullanıcı ekledikten sonra SaveAsync ile ekleme işlemi yapacağım. Eğer bu iki methodtan birisi bile hatalı çalışırsa herhangi bir işlemi yapmayacak ve oluşabilecek hataları bu şekilde ortadan kaldırmış olacağız.
       Task<int> SaveAsync(); //Veritabanın da birçok işlemi yaptıkdan sonra asenkron bir şekilde save işlemi yapacağız.
    }
}
