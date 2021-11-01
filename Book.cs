using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory2
{
    class Book : IComparable
    {
        public Book(int price)
        {
            Price = price;
        }
        public Book()
        {

        }
        public Book(string SerialNumber, string Title, DateTime YearOfPub, decimal Price, uint Quantity)
        {
            this.SerialNumber = SerialNumber;
            this.Title = Title;
            this.YearOfPub = YearOfPub;
            this.Price = Price;
            this.Quantity = Quantity;
        }
        private string serialNumber;
        public string SerialNumber
        {
            get
            {
                return serialNumber;
            }
            set
            {
                serialNumber = value;
            }
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        private DateTime yearOfPub;
        public DateTime YearOfPub
        {
            get
            {
                return yearOfPub;
            }
            set
            {
                yearOfPub = value;
            }
        }
        private decimal price;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value >= 0)
                {
                    price = value;
                }
                else
                {
                    throw new Exception("Свойству Price было присвоено значение меньше 0. Price не может быть меньше 0.");
                }
            }
        }
        private uint quantity;
        public uint Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }
        public decimal PriceAllBooks
        {
            get
            {
                return price * quantity;
            }
        }
        public void PriceChangePercent(decimal percent)
        {
            if (percent > -100)
            {
                price = price + (percent / 100) * price;
            }
            else
            {
                throw new Exception("Аргумент decimal percent метода PriceChangePercent меньше -100, что приведет к значению меньше 0 поля price");
            }
        }
        public string GetInformation()
        {
            return $"Серийный номер: {SerialNumber}\nКнига: {Title}\nГода: {YearOfPub}\nЦена: " +
                $"{Price}\nКоличество на складе: {Quantity}\nОбщая цена: {PriceAllBooks}";
        }

        public int CompareTo(object obj) // Сравнение по цене
        {
            if (obj is Book item)
            {
                if (Price < item.Price)
                    return -1;
                if (Price > item.Price)
                    return 1;
                else
                    return 0;
            }
            throw new ArgumentException();
        }
    }
}
