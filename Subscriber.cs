namespace Sale;

public class Subscriber(string _id, string _region, SubscriptionStatus _status, int _tenureMonths, int _devices, double _basePrice)
{
  public string Id { get; private set; } = string.IsNullOrWhiteSpace(_id) ? throw new ArgumentException("Id required") : _id;
  public string Region { get; private set; } = string.IsNullOrWhiteSpace(_region) ? throw new ArgumentException("Region required") : _region;
  public SubscriptionStatus Status { get; private set; } = _status;
  public int TenureMonths { get; private set; } = _tenureMonths < 0 ? throw new ArgumentOutOfRangeException($"expected {nameof(_tenureMonths)} >= 0, but given: {_tenureMonths}") : _tenureMonths;
  public int Devices { get; private set; } = _devices < 0 ? throw new ArgumentOutOfRangeException($"expected {nameof(_devices)} >= 0, but given: {_devices}") : _devices;
  public double BasePrice { get; private set; } = _basePrice < 0 ? throw new ArgumentOutOfRangeException($"expected {nameof(_basePrice)} >= 0, but given: {_basePrice}") : _basePrice;

  public bool IsPro => Status == SubscriptionStatus.Pro;
}
