using StatePattern.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace StatePattern.Enemy
{
    public class TeleportingState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public TeleportingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            // Teleport the enemy to a random position.
            TeleportToRandomPosition();

            // Transition to the CHASING state after teleporting.
            stateMachine.ChangeState(States.CHASING);
        }

        public void Update() { }

        public void OnStateExit() { }
        private void TeleportToRandomPosition() => Owner.Agent.Warp(GetRandomNavMeshPoint());

        // Generates a random NavMesh position within the teleporting radius.
        private Vector3 GetRandomNavMeshPoint()
        {
            // Calculate a random direction within the teleporting radius.
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * Owner.Data.TeleportingRadius + Owner.Position;
            NavMeshHit hit;

            // Try to find a valid NavMesh position within the radius, return spawn position if not found.
            if (NavMesh.SamplePosition(randomDirection, out hit, Owner.Data.TeleportingRadius, NavMesh.AllAreas))
                return hit.position;

            return Owner.Data.SpawnPosition;
        }
    }
}
