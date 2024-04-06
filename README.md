# Exercises

# Exercise 01

Today we will work on a updated version of Nozama - which can be found on the saga branch of [Nozama repository](https://gitlab.au.dk/swwao/nozama/-/tree/saga?ref_type=heads)

* Firstly get this up and running - this consists of 3 new services, `OrderService`, `PaymentService`, and `InventoryService`.
    * If you can't get the Compose file to work - start the services manually  (through VS) and attach them to the same database - should require less resources.

The main tasks today is to setup a SAGA, which takes an order via the `OrderService`, then handle payment through the `PaymentSevice`, and if that succeeds updates the `InventoryService`. 

The three Services should have endpoints for the basic functionality. You are welcome to add endpoints as needed.

All of these steps can go wrong for varius reasons. 

* Which style of SAGA do you want to implement and why - discuss with your group?

* Implement this either via a Coreographed or Orchestrated SAGAs with all the services - you can choose whichever language and/or tools you need to make this implementation.
    * Make sure you account for all expected business failues.

* You now decide that you need a `ShoppingCart` concept in `ProductCatalog` service, which should be the starting point for your SAGA. Create an endpoint to add to a `Cart` and do a `Checkout`.

* Update you SAGA to initiate when the `Checkout` is called.
    * How easy was is to update to SAGA?

* Are other groups implementing a different style - go around an see/ask - how do their solution look compared to yours?

* *Optional*: You are of course welcome to try and implement it using both styles
