using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WareHS_console
{
    [Serializable]
    public class WareHouse
    {
        public List<Ware> _allWare = new List<Ware>();
        public WareHouse(bool load)
        {
            _allWare = new List<Ware>();
            if (load)
            {
                _allWare = Deserialize("WareList.json");
            }
        }

        public List<Ware> Deserialize(string fileName)
        {
            if (File.Exists(fileName))
            {
                string jsonStr = File.ReadAllText(fileName);
                List<Ware> result = JsonSerializer.Deserialize<List<Ware>>(jsonStr);
                for (int i = 0; i < result.Count; i++)
                {
                    Ware.MaximumId = Math.Max(Ware.MaximumId, result[i].Id);
                }
                return result;
            }
            else return new List<Ware>();
        }

        public void Serialize(string fileName)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonStr = JsonSerializer.Serialize(_allWare, options);

            File.WriteAllText(fileName, jsonStr);
        }

        public void AddWare(Ware ware)
        {
            _allWare.Add(ware);
        }

        public void AddWare(string name, double price,
            DateTime? receiptDate,
            DateTime shippingDate,
            DateTime disposalDate)
        {
            AddWare(new Ware(name, price, receiptDate, shippingDate, disposalDate));
        }

        public List<Ware> AllWare
        {
            get { return _allWare; }
            set { _allWare = value; }
        }


        public Ware FindById(int id)
        {
            Ware ware = null;
            for (int i = 0; i < _allWare.Count; i++)
            {
                if (_allWare[i].Id == id)
                {
                    ware = _allWare[i];
                }
            }
            return ware;
        }

        public void RemoveById(int id)
        {
            for (int i = 0; i < _allWare.Count; i++)
            {
                if (_allWare[i].Id == id)
                {
                    _allWare.RemoveAt(i);
                }
            }
        }
        public void UpdateName(int id, string name)
        {
            FindById(id).Name = name;
        }

        public void UpdatePrice(int id, double price)
        {
            FindById(id).Price = price;
        }

        public void UpdateReceiptDate(int id, DateTime receiptDate)
        {
            FindById(id).ReceiptDate = receiptDate;
        }

        public void UpdateShippingDate(int id, DateTime shippingDate)
        {
            FindById(id).ShippingDate = shippingDate;
        }

        public void UpdateDisposalDate(int id, DateTime disposalDate)
        {
            FindById(id).DisposalDate = disposalDate;
        }
    }
}
