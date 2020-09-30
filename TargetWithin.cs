using System;
using System.Collections.Generic;
using System.Text;

namespace behavior_tree
{
    class TargetWithin : Behavior
    {
        Agent target;
        float distance;
        public TargetWithin(Agent target, float distance)
        {
            this.target = target;
            this.distance = distance;
        }
        public override BehaviorResult Execute(Agent agent, float dt)
        {
            if ((agent.position - target.position).Magnitude() <= distance)
            {
                return BehaviorResult.Success;
            }
            return BehaviorResult.Failure;
        }
    }
}
