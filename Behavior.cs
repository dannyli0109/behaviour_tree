using System;
using System.Collections.Generic;
using System.Text;

namespace behavior_tree
{

    public enum BehaviorResult
    {
        Success,
        Failure,
        Pending
    }

    abstract class Behavior
    {
        public abstract BehaviorResult Execute(Agent agent, float dt);
    }
}
