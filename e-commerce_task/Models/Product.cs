namespace e_commerce_task.Models
{
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public abstract bool IsExpired();
        public virtual bool RequiresShipping() => false;
        public virtual double GetWeight() => 0;

    }
}


