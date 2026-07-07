namespace Space_Shooter_game
{
    public abstract class Enemy : Combatant
    {
        public int ScoreValue;

        protected Enemy(float x, float y, float speed, float collisionRadius, int maxHP, int scoreValue)
            : base(x, y, speed, collisionRadius, maxHP)
        {
            ScoreValue = scoreValue;
        }

        public override void Move()
        {
            Y += Speed;
        }

        public abstract void Shoot();
    }
}