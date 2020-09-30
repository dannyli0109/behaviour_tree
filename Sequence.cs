using System;
using System.Collections.Generic;
using System.Text;

namespace behavior_tree
{
    class Sequence : Composite
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
                if (result == BehaviorResult.Failure) return BehaviorResult.Failure;
                if (result == BehaviorResult.Pending)
                {
                    pendingChild = child;
                    return BehaviorResult.Pending;
                }
            }
            return BehaviorResult.Success;
        }
    }
}
