namespace e_commerce_task.Services
{
    public class ShippingService
    {
        public static double CalculateShippingFee(List<(IShippable item, int quantity)> items)
        {
            double totalWeight = 0;
            Console.WriteLine("\n** Shipment notice **");
            foreach (var (item, quantity) in items)
            {
                double itemWeight = item.GetWeight() * quantity;
                totalWeight += itemWeight;
                Console.WriteLine($"{quantity}x {item.GetName()} {itemWeight * 1000}g");
            }

            Console.WriteLine($"Total package weight {totalWeight}kg");
            return totalWeight * 30;
        }
    }
}
