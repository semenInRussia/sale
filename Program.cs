using Sale;

var subscribers = new List<Subscriber> {
    new("A1", "EU", SubscriptionStatus.Trial, 0, 1, 9),
    new("B2", "US", SubscriptionStatus.Pro, 18, 4, 14),
    new("C3", "EU", SubscriptionStatus.Student, 6, 2, 12),
};

foreach (var s in subscribers)
{
    Console.WriteLine($"Student #{s.Id}: with price={BillingService.CalcTotal(s)}");
}
