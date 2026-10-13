using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp65
{
    internal class Program
    {//Работа с Обобщениями (generic) C#;
        static void Main(string[] args)
        {
            Repositly<Product> product = new Repositly<Product>();
            product.Add(new Product { Id = 1, Name = "Смартфон", Price = 5999 });
            product.Add(new Product { Id = 2, Name = "Наушники", Price = 4990 });
            Product product1 = product.GETByID(1);
            Console.WriteLine($"Найден товар: {product1.Name} за {product} руб.");
            Console.WriteLine(new string('-', 30));
            Repositly<User> repositly = new Repositly<User>();
            repositly.Add(new User { Id = 1, Email = "aznaurguseynov83@gmail.com" });
            repositly.Add(new User { Id = 2, Email = "aznau@gmail.com" });
            User user = repositly.GETByID(2);
            Console.WriteLine($"Найден пользователь с Email: {user.Email}");


        }
    }
    //базовый класс для все сущностей
    public abstract class Entity
    {
        public int Id { get; set; }
    }
    //Модель товара
    public class Product: Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }


    }
    //Модель пользователя
    public class User : Entity
    {
        public string Email { get; set; }
    }
    public class Repositly<T> where T : Entity 
    {
        private readonly List<T> _storage = new List<T>();
        public void Add(T item) 
        {
            _storage.Add(item);
            Console.WriteLine($"[УСПЕХ] Элемент типа {typeof(T).Name}С ID {item.Id} добавлен");

        }
        public T GETByID(int id) 
        {
            return _storage.FirstOrDefault(item=> item.Id == id);
        }
        public List<T> GetAll()
        { return _storage; }
    }

}
