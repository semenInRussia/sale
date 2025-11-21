namespace Sale;

public class BillingService
{
  private static double ApplyStatusDiscount(SubscriptionStatus status, int tenure, double basePrice) => status switch
  {
    SubscriptionStatus.Trial => 0,
    SubscriptionStatus.Student => basePrice * 0.5,
    SubscriptionStatus.Pro when tenure >= 24 => basePrice * 0.85,
    SubscriptionStatus.Pro when tenure >= 12 => basePrice * 0.10,
    SubscriptionStatus.Pro => basePrice,
    _ => basePrice,
  };

  public static double CalcTotal(Subscriber s)
  {
    ArgumentNullException.ThrowIfNull(s);

    double PriceAfterStatus() => ApplyStatusDiscount(s.Status, s.TenureMonths, s.BasePrice);
    double WithDevices(double x) => s.Devices > 3 ? x + 4.99 : x;
    double WithTax(double x) => s.Region switch
    {
      "EU" => x * 1.21,
      "US" => x * 1.07,
      _ => x,
    };

    return WithTax(WithDevices(PriceAfterStatus()));
  }

  public static (bool Ok, string Error) TryValidate(Subscriber s)
  {
    if (s is null) return (false, "No subscriber");
    if (string.IsNullOrWhiteSpace(s.Id)) return (false, "Id missing");
    if (s.BasePrice < 0) return (false, "Price < 0");
    return (true, "");
  }
}
