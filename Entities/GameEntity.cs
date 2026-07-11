using System;
using System.Drawing;

namespace Space_Shooter_game
{
    public abstract class GameEntity
    {
        public float X;
        public float Y;
        public float Speed;
        public float CollisionRadius;
        public float RotationAngle;

        protected GameEntity(float x, float y, float speed, float collisionRadius)
        {
            X = x;
            Y = y;
            Speed = speed;
            CollisionRadius = collisionRadius;
        }

        public abstract void Move(Player player);
        public abstract void Draw(Graphics g);

        public virtual bool IsCollidingWith(GameEntity other)
        {
            float dx = X - other.X;
            float dy = Y - other.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);
            return distance <= (CollisionRadius + other.CollisionRadius);
        }

        protected void ApplyTilt(float horizontalDelta, float maxAngle = 25f, float smoothing = 0.3f)
        {
            float ratio = Speed > 0 ? horizontalDelta / Speed : 0f;
            ratio = Math.Clamp(ratio, -1f, 1f);
            float target = ratio * maxAngle;
            RotationAngle += (target - RotationAngle) * smoothing;
        }
    }
}