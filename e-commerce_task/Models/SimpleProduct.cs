namespace e_commerce_task.Models
{
    class SimpleProduct : Product
    {
        public SimpleProduct(string name, double price, int quantity)
            : base(name, price, quantity)
        {
        }

        public override bool IsExpired() => false;
    }
}
