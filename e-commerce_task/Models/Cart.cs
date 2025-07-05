namespace e_commerce_task.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; } = new();

        public void Add(Product product, int quantity)
        {
            if (product.Quantity < quantity)
                Console.WriteLine($"Not enough quantity for {product.Name}");

            Items.Add(new CartItem(product, quantity));
        }

        public bool IsEmpty() => !Items.Any();
    }
}
