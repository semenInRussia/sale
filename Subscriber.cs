namespace Sale;

public class Subscriber
{
  public string Id { get; private set; }
  public string Region { get; private set; }
  public SubscriptionStatus Status { get; private set; }
  public int TenureMonths { get; private set; }
  public int Devices { get; private set; }
  public double BasePrice { get; private set; }

  public Subscriber(string id, string region, SubscriptionStatus status, int tenureMonths, int devices, double basePrice)
  {
    Id = id;
    Region = region;
    Status = status;
    Devices = devices;
    BasePrice = basePrice;
    TenureMonths = tenureMonths;
    var (ok, err) = BillingService.Validate(this);
    if (!ok)
    {
      throw new ArgumentOutOfRangeException($"Can't construct subscriber: {err}");
    }
  }


  public bool IsPro => Status == SubscriptionStatus.Pro;
}
