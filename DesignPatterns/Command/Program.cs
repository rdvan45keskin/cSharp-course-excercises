using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager,5);
            SellStock sellStock = new SellStock(stockManager,3);

            StockController stockController = new StockController();
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            stockController.TakeOrder(buyStock);

            stockController.PlaceOrders();
        }
    }

    class StockManager
    {
        string _name = "Laptop";
        int _quantity = 10;

        public void Buy(int orderQuantity)
        {
            _quantity += orderQuantity;
            Console.WriteLine($"Stock : {_name}, {orderQuantity} bought! New quantity: {_quantity}");
        }

        public void Sell(int orderQuantity)
        {
            if (_quantity >= orderQuantity)
            {
                _quantity -= orderQuantity;
                Console.WriteLine($"Stock : {_name}, {orderQuantity} sold! New quantity: {_quantity}");
            }
            else
            {
                Console.WriteLine($"Not enough stock to sell {orderQuantity} units! Quantity is: {_quantity}");
            }
        }
    }

    interface IOrder 
    {
        void Execute();

    }
    class BuyStock : IOrder
    {
        StockManager _stockManager;
        int _orderQuantity;

        public BuyStock(StockManager stockManager, int orderQuantity)
        {
            _stockManager = stockManager;
            _orderQuantity = orderQuantity;
        }

        public void Execute()
        {
            _stockManager.Buy(_orderQuantity);
        }
    }

    class SellStock : IOrder
    {
        StockManager _stockManager;
        int _orderQuantity;

        public SellStock(StockManager stockManager, int orderQuantity)
        {
            _stockManager = stockManager;
            _orderQuantity = orderQuantity;
        }
        public void Execute()
        {
            _stockManager.Sell(_orderQuantity);
        }
    }

    class StockController
    {
        List<IOrder> _orders = new List<IOrder>();
        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void PlaceOrders()
        {
            foreach (IOrder order in _orders)
            {
                order.Execute();
            }

            _orders.Clear();
        }
    }
}
