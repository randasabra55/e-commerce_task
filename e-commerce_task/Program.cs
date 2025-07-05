
using e_commerce_task.Models;

class Program
{
    static void Main(string[] args)
    {
        var cheese = new ShippableProduct("Cheese", 100, 5, 0.2);
        var biscuits = new ShippableProduct("Biscuits", 150, 2, 0.35);
        var scratchCard = new SimpleProduct("Scratch Card", 50, 10);
        var pro = new ExpirableProduct("pro", 100, 20, new DateTime(2024, 12, 1));
        var customer = new Customer("Randa", 1000);

        var cart = new Cart();
        cart.Add(cheese, 2);
        cart.Add(biscuits, 2);
        cart.Add(scratchCard, 1);
        //cart.Add(pro, 1);
        CheckoutService.Checkout(customer, cart);
    }
}

