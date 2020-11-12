using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Data
{
    public class DbInitializer
    {
        public static void Initialize(Lab4Context db)
        {
            db.Database.EnsureCreated();
            // Проверка занесены ли продукты 
            if (db.Products.Any())
            {
                return;   // База данных инициализирована
            }

            int customers_number = 35;
            int products_number = 35;
            int orders_number = 300;

            string customerName;
            string customerAddress;
            int customerNum;

            string productName;
            string productStorage;
            string productPackaging;

            string orderDelivery;
            int orderVolume;

            Random randObj = new Random(1);

            //Заполнение таблицы Продукты
            string[] pname_voc = { "Молоко_", "Конфеты_", "Хлеб_", "Печенье_", "Сок_", "Мясо_", "Рыба_", "Творог_", "Консервы_"};
            string[] storage_voc = { "Полочное", "Консольное", "Мезонины", "Складские платформы"};
            string[] packaging_voc = { "Картон", "Бумага", "Пластик", "Жестяная банка", "Целлофан"};
            int count_pname_voc = pname_voc.GetLength(0);
            int count_storage_voc = storage_voc.GetLength(0);
            int count_packaging_voc = packaging_voc.GetLength(0);
            for (int productId = 1; productId <= products_number; productId++)
            {
                productName = pname_voc[randObj.Next(count_pname_voc)] + productId.ToString();
                productStorage = storage_voc[randObj.Next(count_storage_voc)];
                productPackaging = packaging_voc[randObj.Next(count_packaging_voc)];
                db.Products.Add(new Product { ProductName = productName, Storage = productStorage, Packaging = productPackaging });
            }
            db.SaveChanges();

            //Заполнение таблицы Заказчики
            string[] cname_voc = { "ОАО", "ЗАО", "ЧТУП", "ООО", "ОДО" };
            string[] caddress_voc = { "Огоренко_", "Свиридова_", "Головацкого_", "Петруся_Бровки_", "Советская_" };
            int count_cname_voc = cname_voc.GetLength(0);
            int count_caddress_voc = caddress_voc.GetLength(0);
            for (int customerId = 1; customerId <= customers_number; customerId++)
            {
                customerName = cname_voc[randObj.Next(count_cname_voc)] + customerId.ToString();
                customerAddress = caddress_voc[randObj.Next(count_caddress_voc)] + customerId.ToString();
                customerNum = randObj.Next(111111, 999999);
                db.Customers.Add(new Customer { CustomerName = customerName, CustomerAddress = customerAddress, TelNumber = customerNum });
            }
            db.SaveChanges();

            //Заполнение таблицы Заказы
            for (int orderId = 1; orderId <= orders_number; orderId++)
            {
                int productId = randObj.Next(1, products_number - 1);
                int customerId = randObj.Next(1, customers_number - 1);
                orderDelivery = "Доставка_" + orderId.ToString();
                orderVolume = randObj.Next(10, 90);

                DateTime today = DateTime.Now.Date;
                DateTime orderDate = today.AddDays(-orderId);
                db.Orders.Add(new Order { ProductId = productId, CustomerId = customerId, Delivery = orderDelivery, Volume = orderVolume, OrderDate = orderDate });
            }
            db.SaveChanges();

        }
    }
}
