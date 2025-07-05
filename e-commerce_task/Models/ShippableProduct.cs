
using e_commerce_task.Services;

namespace e_commerce_task.Models
{
    public class ShippableProduct : Product, IShippable
    {
        public double Weight { get; }

        public ShippableProduct(string name, double price, int quantity, double weight)
            : base(name, price, quantity)
        {
            Weight = weight;
        }

        public override bool IsExpired() => false;
        public override bool RequiresShipping() => true;
        public override double GetWeight() => Weight;

        public string GetName() => Name;
        double IShippable.GetWeight() => Weight;

    }
}
