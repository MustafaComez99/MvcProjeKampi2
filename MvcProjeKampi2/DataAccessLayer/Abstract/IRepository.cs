using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>//t type demek. Hangi entity gönderilirse.
    {
        //CRUD operasyonlarını birer metod olarak tanımlayacağız.
        //Listeleme için bir metod tanımlayacağız.
        List<T> List();

        //Ekleme
        void Insert(T p);

        //GetbyId 
        T Get(Expression<Func<T, bool>> filter);

        //Güncelleme
        void Update(T p);

        //Silme
        void Delete(T p);

        //Şartlı Listeleme
         List<T> List(Expression<Func<T, bool>> filter);
    }
}
