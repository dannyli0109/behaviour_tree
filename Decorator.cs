using System;
using System.Collections.Generic;
using System.Text;

namespace behavior_tree
{
    abstract class Decorator : Behavior
    {
        protected Behavior child;
        public Decorator(Behavior child)
        {
            this.child = child;
        }
    }
}
