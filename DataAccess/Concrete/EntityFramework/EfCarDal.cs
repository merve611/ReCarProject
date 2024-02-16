using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RecarContext context = new RecarContext())
            {
               var addedEntity = context.Entry(entity);         //referansı yakala
                addedEntity.State = EntityState.Added;          //o aslında eklenecek bir nesne
                context.SaveChanges();                          //ekle

            }
        }

        public void Delete(Car entity)
        {
            using (RecarContext context = new RecarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RecarContext context = new RecarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RecarContext context = new RecarContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();                                         //filter null ise DB deki Car tablosuna yerleş listeye çevir ve onu bana ver (select * from car çalıştırır arka planda ) filter null değilse filtreleyip ver
            }
        }

        public void Update(Car entity)
        {
            using (RecarContext context = new RecarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
