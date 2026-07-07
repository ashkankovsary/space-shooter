namespace Space_Shooter_game
{
    public abstract class Combatant : GameEntity
    {
        public int MaxHP;
        public int CurrentHP;

        public bool IsDead => CurrentHP <= 0;

        protected Combatant(float x, float y, float speed, float collisionRadius, int maxHP)
            : base(x, y, speed, collisionRadius)
        {
            MaxHP = maxHP;
            CurrentHP = maxHP;
        }

        public virtual void TakeDamage(int amount)
        {
            CurrentHP -= amount;
            if (CurrentHP < 0)
                CurrentHP = 0;
        }
    }
}