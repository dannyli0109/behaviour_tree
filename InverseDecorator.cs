using System;
using System.Collections.Generic;
using System.Text;

namespace behavior_tree
{
    class InverseDecorator : Decorator
    {
        public InverseDecorator(Behavior child) : base(child) {}
        public override BehaviorResult Execute(Agent agent, float dt)
        {
            BehaviorResult result = child.Execute(agent, dt);
            switch(result)
            {
                case BehaviorResult.Success:
                    return BehaviorResult.Failure;
                case BehaviorResult.Failure:
                    return BehaviorResult.Success;
                default:
                    return result;
            }
        }
    }
}
