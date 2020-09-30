using System;
using System.Collections.Generic;
using System.Text;

namespace behavior_tree
{
    class Seek : Behavior
    {
        float maxSpeed;
        Agent target;
        public Seek(Agent target, float maxSpeed)
        {
            this.target = target;
            this.maxSpeed = maxSpeed;
        }

        public override BehaviorResult Execute(Agent agent, float dt)
        {
            Vector3 desireVelocity = (target.position - agent.position).GetNormalize() * maxSpeed;
            Vector3 steeringForce = desireVelocity - agent.velocity;
            agent.velocity += steeringForce * dt;
            return BehaviorResult.Success;
        }
    }
}
