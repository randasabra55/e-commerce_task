# E-Commerce System (Fawry Internship Task)

This project is an implementation of a simple e-commerce system as part of the **Fawry Quantum Internship Challenge**.  
It allows customers to add products to a cart, handle shipping for applicable items, and perform checkout with all necessary validations.

---

## Features

- Define products with:
  - Name
  - Price
  - Quantity
- Products may:
  - Be expirable (e.g., Cheese, Biscuits)
  - Require shipping (e.g., Cheese, TV)
  - Be digital/non-shippable (e.g., Scratch Cards)
- Customers can:
  - Add items to their cart with specific quantity
  - Checkout and see:
    - Subtotal
    - Shipping fees
    - Total paid
    - Updated balance
- Handles edge cases:
  - Expired items
  - Insufficient stock
  - Insufficient balance
  - Empty cart
- ShippingService calculates shipping fees based on weight

---

## Assumptions

1. **Checkout Process**
   - All products added to the cart are included in the checkout.
   - Products that do **not** require shipping are still billed and shown in the final receipt.
   - Only products that **require shipping** and implement `IShippable` are sent to the `ShippingService`.

2. **Validation Rules**
   - The checkout is **aborted completely** if:
     - Any product is expired
     - Any product is out of stock
     - The cart is empty
     - The customer's balance is insufficient

3. **Shipping Calculation**
   - Shipping fee = **30 LE per 1 kg**
   - The system prints:
     - Quantity x Product Name
     - Total weight in grams
     - Overall shipping fee

4. **After Successful Checkout**
   - Product quantities are updated
   - Customer balance is deducted
   - The cart is cleared

5. **No Partial Orders**
   - If there's an error with **any item**, the whole checkout is canceled.
   - No partial processing is allowed.

6. **Expiration Logic**
   - Products are expired if `current date > ExpiryDate`.
  



## Example 

var cheese = new ShippableProduct("Cheese", 100, 5, 0.2);                                                                                                              
var biscuits = new ShippableProduct("Biscuits", 150, 2, 0.35);                                           
var scratchCard = new SimpleProduct("Scratch Card", 50, 10);
var customer = new Customer("Randa", 1000);

var cart = new Cart();
cart.Add(cheese, 2);
cart.Add(biscuits, 2);
cart.Add(scratchCard, 1);

CheckoutService.Checkout(customer, cart);

## Samaple output

** Shipment notice **
2x Cheese 400g
2x Biscuits 700g
Total package weight 1.1kg

** Checkout receipt **
2x Cheese 200
2x Biscuits 300
1x Scratch Card 50
----------------------
Subtotal 550
Shipping 33
Amount 583
Customer balance: 417

## How to Run

Clone the repo
Open the project in visual studio
run this
