using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Enemy
{
    public class PatrolManStateMachine : IStateMachine
    {
        private EnemyController Owner;
        private IState currentState;
        protected Dictionary<States, IState> States = new Dictionary<States, IState>();

        public PatrolManStateMachine(PatrolManController Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(Enemy.States.IDLE, new IdleState(this));
            States.Add(Enemy.States.PATROLLING, new PatrollingState(this));
            States.Add(Enemy.States.CHASING, new ChasingState(this));
            States.Add(Enemy.States.SHOOTING, new ShootingState(this));
        }

        private void SetOwner()
        {
            foreach (IState state in States.Values)
            {
                state.Owner = Owner;
            }
        }

        public void ChangeState(States newState)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
