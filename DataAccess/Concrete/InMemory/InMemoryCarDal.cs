using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()     //Projeyi başlatınca bellekte araba listesi oluşsun - constructor metodu
        {
            _cars = new List<Car> {
                new Car{CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 500, ModelYear = new DateTime(2022), Description = "Konforlu araba"},
                new Car{CarId = 2, BrandId = 1, ColorId = 2, DailyPrice = 1000, ModelYear = new DateTime(2023), Description = "Yeni Nesil araba"},
                new Car{CarId = 3, BrandId = 2, ColorId = 3, DailyPrice = 300, ModelYear = new DateTime(2019), Description = "Aile araba"},
                new Car{CarId = 4, BrandId = 2, ColorId = 1, DailyPrice = 400, ModelYear = new DateTime(2020), Description = "Konforlu araba"},
                new Car{CarId = 5, BrandId = 3, ColorId = 2, DailyPrice = 200, ModelYear = new DateTime(2016), Description = "Uygun fiyatlı araba"},


            };      
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId == car.CarId );
            
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c=>c.CarId ==id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;


        }
    }
}
