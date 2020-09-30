using System;
using System.Collections.Generic;
using System.Text;

namespace behavior_tree
{
    class Wait : Behavior
    {
        float time;
        float maxTime;

        public Wait(float time, float maxTime)
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
                return BehaviorResult.Success;
            }
            return BehaviorResult.Pending;
        }
    }
}
