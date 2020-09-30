using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace behavior_tree
{
    class Selector : Composite
    {
        public override BehaviorResult Execute(Agent agent, float dt)
        {
            Behavior child = pendingChild;
            pendingChild = null;
            if (children.Count == 0) return BehaviorResult.Failure;
            if (child == null) child = children[0];
            int index = children.IndexOf(child);
            for (int i = index; i < children.Count; i++)
            {
                child = children[i];
                BehaviorResult result = child.Execute(agent, dt);
                if (result == BehaviorResult.Success) return BehaviorResult.Success;
                if (result == BehaviorResult.Pending)
                {
                    pendingChild = child;
                    return BehaviorResult.Pending;
                }
            }
            return BehaviorResult.Failure;
        }
    }
}
