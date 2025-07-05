
using e_commerce_task.Models;
using e_commerce_task.Services;

class CheckoutService
{
    public static void Checkout(Customer customer, Cart cart)
    {
        if (cart.IsEmpty())
        {
            Console.WriteLine("Cart is empty");
            return;
        }

        double subtotal = 0;
        var shippableItems = new List<(IShippable item, int quantity)>();
        var errors = new List<string>();

        foreach (var item in cart.Items)
        {
            var product = item.product;

            if (product.IsExpired())
            {
                errors.Add($"{product.Name} is expired");
                continue;
            }

            if (product.Quantity < item.quantity)
            {
                errors.Add($"Not enough quantity for {product.Name}");
                continue;
            }
        }

        if (errors.Any())
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
            return;
        }

        foreach (var item in cart.Items)
        {
            var product = item.product;

            subtotal += item.GetTotalPrice();
            product.Quantity -= item.quantity;

            if (product.RequiresShipping() && product is IShippable shippable)
            {
                shippableItems.Add((shippable, item.quantity));
            }
        }

        double shippingFee = ShippingService.CalculateShippingFee(shippableItems);
        double totalAmount = subtotal + shippingFee;

        if (customer.Balance < totalAmount)
        {
            Console.WriteLine("Insufficient balance");
            return;
        }

        customer.Balance -= totalAmount;

        Console.WriteLine("\n** Checkout receipt **");
        foreach (var item in cart.Items)
        {
            Console.WriteLine($"{item.quantity}x {item.product.Name} {item.GetTotalPrice()}");
        }

        Console.WriteLine("----------------------");
        Console.WriteLine($"Subtotal {subtotal}");
        Console.WriteLine($"Shipping {shippingFee}");
        Console.WriteLine($"Amount {totalAmount}");
        Console.WriteLine($"Customer balance: {customer.Balance}");

        cart.Items.Clear();
    }
}
