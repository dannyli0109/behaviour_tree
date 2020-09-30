using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace behavior_tree
{
    class Attack : Behavior
    {
        public override BehaviorResult Execute(Agent agent, float dt)
        {
            Console.WriteLine("Attacking");
            agent.velocity *= 0;
            return BehaviorResult.Success;
        }
    }
}
