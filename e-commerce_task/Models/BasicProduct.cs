namespace e_commerce_task.Models
{
    class BasicProduct : Product
    {
        public BasicProduct(string name, double price, int quantity)
            : base(name, price, quantity)
        {
        }

        public override bool IsExpired() => false;
    }
}
