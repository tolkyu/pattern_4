using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CarZ
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Car car1 = new Car("BMW", "1337AB", 12333, 12222);
            car1 = new CarDecoratorDiscount(car1) { Discount = 0.7, AdditionalDistance = 50 };
            Car car2 = new Car("Porsche", "0707AE", 34444, 17000);
            car2 = new CarDecoratorUser("Name", "Surname", car2);
            WriteLine("\t-------------------------------------");
            WriteLine("\tFirst car with discount");
            WriteLine("\t-------------------------------------");
            WriteLine(car1);
            WriteLine("\t-------------------------------------");
            WriteLine("\tSecond car with user info");
            WriteLine("\t-------------------------------------");
            WriteLine(car2);

        }

    }
    public class Car
    {
        public string Model { get; set; }
        public string CarNum { get; set; }
        public double Price;
        public double Distance;
        public virtual double getPrice()
        {
            return Price;
        }
        public virtual double getDistance()
        {
            return Distance;
        }
        public Car()
        {

        }

        public Car(string model, string carNum, double price, double distance)
        {
            this.Model = model;
            this.CarNum = carNum;
            this.Price = price;
            this.Distance = distance;
        }
        public override string ToString()
        {
            return $"Model : \t{Model}\n Car number : \t{CarNum}\nPrice per 24h : \t{getPrice()}\nMax distance :{Distance}";
        }

    }
    public class CarDecoratorDiscount : Car
    {
        Car car;
        public double Discount { get; set; }
        public double AdditionalDistance { get; set; }

        public CarDecoratorDiscount(Car car) : base(car.Model, car.CarNum, car.getPrice(), car.getDistance())
        {
            this.car = car;
        }
        public override double getPrice()
        {
            return car.getPrice() * Discount;
        }
        public override double getDistance()
        {
            return car.Distance + AdditionalDistance;
        }
        public override string ToString()
        {
            return $"\tModel: {Model}\n\tCar number: {CarNum}\n\tRent price: {getPrice()}\n\tMax distance: {Distance}\n\tTotal price with discount: {getPrice()}\n\tMax distance with addons: {getDistance()}";
        }
    }
    public class CarDecoratorUser : Car
    {
        public string Fullname { get; set; }
        public string ID { get; set; }
        public CarDecoratorUser(string fullname, string ID, Car car) : this(car)
        {
            this.Fullname = fullname;
            this.ID = ID;
        }
        public CarDecoratorUser(Car car)
            : base(car.Model, car.CarNum, car.getPrice(), car.getDistance())
        {

        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine($"\tModel {Model.ToString()}");
            info.AppendLine($"\tCar number  {CarNum}");
            info.AppendLine($"\tPrice per 24h  {getPrice()}");
            info.AppendLine($"\tMax distance : {Distance}");
            info.AppendLine($"\t{Fullname}");
            info.AppendLine($"\t{ID}");
            return info.ToString();
        }
    }

}
