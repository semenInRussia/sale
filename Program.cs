using Sale;

var subscribers = new List<Subscriber>
   {
       new("A-1", "EU", SubscriptionStatus.Trial, 0, 1, 9.99),
       new("B-2", "US", SubscriptionStatus.Pro, 18, 4, 14.99),
       new("C-3", "EU", SubscriptionStatus.Student, 6, 2, 12.99),
   };

foreach (var s in subscribers)
{
    var (ok, err) = BillingService.Validate(s);
    if (!ok)
    {
        Console.WriteLine("error occured, when validate user with id: ", s.Id);
    }
}
