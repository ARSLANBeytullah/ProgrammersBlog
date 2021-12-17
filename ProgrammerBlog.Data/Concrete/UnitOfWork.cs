using ProgrammerBlog.Data.Abstract;
using ProgrammerBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammerBlog.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerBlog.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgrammersBlogContext _context;
        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;
        private EfRoleRepositoy _roleRepository;
        private EfUserRepository _userRepository;

        public UnitOfWork(ProgrammersBlogContext context) //Dependies injection
        {
            _context = context;
        }



        public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository(_context); //Article.AddAsync denirse ona _articleRepository dönülür. Anca AddAsync değilde null bir değer dönülürse eğer o zaman EfArticleRepository'i newleyerek kullanıcıya gönderiyoruz.

        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context); //Null Coalescing Operatörü(??) bu operatör sayesinde bir değişkenin değerinin null olduğu durumda alternatif değer döndürebiliriz.

        public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_context);

        public IRoleRepository Roles => _roleRepository ?? new EfRoleRepositoy(_context);

        public IUserRepository Users => _userRepository ?? new EfUserRepository(_context);

       

        public async Task<int> SaveAsync() //Bu method bizim contextimizin savechanges methoduna eşit olacak
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
