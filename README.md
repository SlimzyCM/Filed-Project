# Filed-Project

A WebAPI with only 1 method called “ProcessPayment” that receives a request like this
- CreditCardNumber (mandatory, string, it should be a valid CCN)
- CardHolder: (mandatory, string)
- ExpirationDate (mandatory, DateTime, it cannot be in the past)
- SecurityCode (optional, string, 3 digits)
- Amount (mandatoy decimal, positive amount)
<hr />

The response of this method are of the followings based on
- Payment is processed: 200 OK
- The request is invalid: 400 bad request
- Any error: 500 internal server error
- The request should be validated before processed.

<hr />

<p>The payment gateway used to process each payment follows the next set of business
rules: </p>
<ol>
   
<li>If the amount to be paid is less than £20, ICheapPaymentGateway is used </li>
<li>If the amount to be paid is £21-500, IExpensivePaymentGateway used if available. Otherwise, retries only once with ICheapPaymentGateway. </li>
<li>If the amount is > £500, uses only PremiumPaymentService and retries up to 3 times in case payment does not get processed </li>
<li> the payment is Store/update once the processing is completed.
 <ol/>
   
<hr />
  
Implementation Pattern:
- Repository/unit of work patterns
- Eager loading for all entities
- SOLID principles.
- Entity Framework Core.
