namespace Bridge;

/// <summary>
/// Abstraction
/// </summary>
public abstract class Menu
{
    private readonly ICoupon _coupon;

    protected Menu(ICoupon coupon)
    {
        _coupon = coupon;
    }

    protected ICoupon Coupon => _coupon;
    
    public abstract int CalculatePrice();
}

/// <summary>
/// RefinedAbstraction
/// </summary>
public class VegetarianMenu : Menu
{
    public VegetarianMenu(ICoupon coupon) : base(coupon)
    {
    }
    
    public override int CalculatePrice()
    {
        return 42 - base.Coupon.CouponValue;
    }
}

/// <summary>
/// RefinedAbstraction
/// </summary>
public class MeatBaseMenu : Menu
{
    public MeatBaseMenu(ICoupon coupon) : base(coupon)
    {
    }
    
    public override int CalculatePrice()
    {
        return 84 - base.Coupon.CouponValue;
    }
}

/// <summary>
/// Implementor
/// </summary>
public interface ICoupon
{
    int CouponValue { get; }
}

/// <summary>
/// ConcreteImplementor
/// </summary>
public class NoCoupon : ICoupon
{
    public int CouponValue => 0;
} 

/// <summary>
/// ConcreteImplementor
/// </summary>
public class OneEuroCoupon : ICoupon
{
    public int CouponValue => 1;
}

/// <summary>
/// ConcreteImplementor
/// </summary>
public class TwoEuroCoupon : ICoupon
{
    public int CouponValue => 2;
}