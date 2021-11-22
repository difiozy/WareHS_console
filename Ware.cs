using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHS_console
{
    [Serializable]
    public class Ware
    {
        private int _id = 0;
        private static int _maximumId = 0;
        private string _name = "";
        private double _price = 0;

        private DateTime? _receiptDate = DateTime.MinValue; // дата поступления
        private DateTime? _shippingDate = DateTime.MinValue; // дата отгрузки
        private DateTime? _disposalDate = DateTime.MinValue; // дата утилизации

        public Ware()
        {

        }
        public Ware(string name, double price,
            DateTime? receiptDate,
            DateTime shippingDate,
            DateTime disposalDate)
        {
            _maximumId++;
            _id = _maximumId;
            _name = name;
            _price = price;
            _receiptDate = receiptDate;
            _shippingDate = shippingDate;
            _disposalDate = disposalDate;
        }


        public static int MaximumId { get => _maximumId; set => _maximumId = value; }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price; set => _price = value; }
        public DateTime? ReceiptDate { get => _receiptDate; set => _receiptDate = value; }
        public DateTime? ShippingDate { get => _shippingDate; set => _shippingDate = value; }
        public DateTime? DisposalDate { get => _disposalDate; set => _disposalDate = value; }

        public override string ToString()
        {
            string resultString =
                $"id = {Id}, name = {Name}, price = {Price}, ReceiptDate = {ReceiptDate}," +
                $" ShippingDate = {ShippingDate}, DisposalDate = {DisposalDate}";
            return resultString;
        }
    }
}
