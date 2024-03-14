using StatePattern.Enemy;
using StatePattern.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace StatePattern.StateMachine
{
    public class ClonningState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        private float timer;

        public ClonningState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            int cloneCount = (Owner as CloneManController).CloneCountLeft;
            for (int i = 0; i < cloneCount; i++)
            {
                CreateAClone();
            }

        }

        public void Update()
        {

        }

        private void CreateAClone()
        {
            CloneManController clone = GameService.Instance.EnemyService.CreateEnemy(Owner.Data) as CloneManController;
            clone.SetCloneCount((Owner as CloneManController).CloneCountLeft - 1);
            clone.Teleport();
            clone.SetDefaultColor(EnemyColorType.Clone);
            clone.ChangeColor(EnemyColorType.Clone);
            GameService.Instance.EnemyService.AddEnemy(clone);
        }

        public void OnStateExit()
        {

        }
    }
}
