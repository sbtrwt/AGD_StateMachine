using StatePattern.Player;
using StatePattern.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Enemy
{
    public class HitmanController : EnemyController
    {
        private HitmanStateMachine stateMachine;

        public HitmanController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            enemyView.SetController(this);
            CreateStateMachine();
            stateMachine.ChangeState(States.IDLE);
        }

        private void CreateStateMachine() => stateMachine = new HitmanStateMachine(this);

        public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
                return;

            stateMachine.Update();
        }
        public override void Shoot()
        {
            base.Shoot();
            stateMachine.ChangeState(States.TELEPORTING);
        }

        // Player enters range, change to CHASING state.
        public override void PlayerEnteredRange(PlayerController targetToSet)
        {
            base.PlayerEnteredRange(targetToSet);
            stateMachine.ChangeState(States.CHASING);
        }

        // Player exits range, change to IDLE state.
        public override void PlayerExitedRange() => stateMachine.ChangeState(States.IDLE);


    }
}
