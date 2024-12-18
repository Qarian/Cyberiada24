namespace Presentation
{
    public interface IDamagable
    {
        public float Health { get; }
        
        public void Damage(float damage);
    }
}