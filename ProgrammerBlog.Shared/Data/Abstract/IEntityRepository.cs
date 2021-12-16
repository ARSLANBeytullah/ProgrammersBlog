using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        /*Aşğaıda ki ifade şarta göre dilediğimiz şekilde entityleri getirmemize sağlar.
        params Expression<Func<T,object>[]includeproperties> params bize birden çok parametre vermemize olanak sağlar aynı aşağıdaki gibi
        bu sayede şu tarz sorguları yazabiliriz : 25 id'li makaleyi getirirken,makale ile birlikte kullanıcıyı ve yorumlarıda include etmek(birlikte getirmek) istiyoruz.
        var makale = repository.GetAsync(m=>m.id==25,m=>m.User,m=>m.Comments); */
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties); //var kullanici = repository.GetAsync(k=>k.id==15)
        //Tüm katergorileri getirmek için repotisory.GetAllAsync();
        //ID'si 1 olan makaleye ait tüm yorumları getirmek istiyor isek : repository.GetAllAsync(y=>y.ArticleId==1);
        //C# Kategorisine ait tüm makaleleri getirmek istiyoruz. repository.GetAllAsync(m=>m.CategoryName=="C#",m=>m.Category);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);  //predicate'i null verdim çünkü biz makalelerin hepsini yüklemek isteyebiliriz(predicate=null ise hepsi gelir).Sadece c# a özel kategiryide yüklemek isteyebiliriz. İşte o zaman expression'ı ona göre vermemiz gerekmektedir(c=>c..categoryname="c#");
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate); //Bir kullanıcının önceden hesap oluşturup oluşturmadığını sorgulamak için bu methodun imzasını attık.
        Task<int> CountAsync(Expression<Func<T, bool>> pridicate); //Admin panelinde elimizde ki verileri sayısal olarak listelemek isteyebiliriz. Kaç adet makale var ? tarzı...
    }
}
