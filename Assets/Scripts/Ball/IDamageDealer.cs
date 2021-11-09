namespace Ball
{
    public interface IDamageDealer<out TDamage>
    {
        public TDamage DealDamage();
    }
}