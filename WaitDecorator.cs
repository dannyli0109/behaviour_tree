using System;
using System.Collections.Generic;
using System.Text;

namespace behavior_tree
{
    class WaitDecorator : Decorator
    {
        float time;
        float maxTime;
        public WaitDecorator(Behavior child, float time, float maxTime) : base(child)
        {
            this.time = time;
            this.maxTime = maxTime;
        }
        public override BehaviorResult Execute(Agent agent, float dt)
        {
            time += dt;
            if (time >= maxTime)
            {
                time -= maxTime;
                return child.Execute(agent, maxTime);
            }
            return BehaviorResult.Pending;
        }
    }
}
