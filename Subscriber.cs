namespace Sale;

public class Subscriber
{
  public string Id { get; private set; }
  public string Region { get; private set; }
  public string Status { get; private set; }
  public int TenureMonths { get; private set; }
  public int Devices { get; private set; }
  public double BasePrice { get; private set; }

  public Subscriber(string id, string region, string status, int tenureMonths, int devices, double basePrice)
  {
    if (tenureMonths < 0)
    {
      throw new ArgumentOutOfRangeException($"expected {nameof(tenureMonths)} >= 0, but given: {tenureMonths}");
    }

    if (devices < 0)
    {
      throw new ArgumentOutOfRangeException($"expected {nameof(devices)} >= 0, but given: {devices}");
    }

    Id = string.IsNullOrWhiteSpace(id) ? throw new ArgumentException("Id required") : id;
    Region = region;
    Status = status;
    TenureMonths = tenureMonths;
    Devices = devices;
    BasePrice = basePrice;
  }
}
