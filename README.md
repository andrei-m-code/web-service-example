# Exception handling and API response models concept

The solution demonstrates:

* How Exception Handling Middleware works.
* The way to implement exceptions and mapping of exceptions to HTTP status.
* Rough concept of unique error codes.
* Consistent JSON serialization configuration across the solution.
* How we can organize response models and error response models without the use of ActionResult.

It doesn't address:

* Organizing domain models, services, CQRS or infrastructure.
* Some items will have to be taken out and converted into separate Nuget packages e.g. exception handling middleware, ApiResponse classes.
* Anything else not listed in the first list.

For discussion/consideration:

* Response negotiation is ignored - do we only need to support JSON?
* Throwing exceptions when validation errors happen?
* How to better organize ErrorCodes to not duplicate them across different services and within the ErrorCodes.cs itself.
