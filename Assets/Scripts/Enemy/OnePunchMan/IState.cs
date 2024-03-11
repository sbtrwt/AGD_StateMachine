namespace StatePattern.Enemy
{
    public interface IState
    {
        public EnemyController Owner { get; set; }
        public void OnStateEnter();
        public void Update();
        public void OnStateExit();
    }
    public enum States
    {
        IDLE,
        ROTATING,
        SHOOTING,
        PATROLLING,
        CHASING
    }
}