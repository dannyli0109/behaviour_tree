using System;
using System.Collections.Generic;
using System.Text;


namespace behavior_tree
{
    abstract class Composite : Behavior
    {
        public List<Behavior> children = new List<Behavior>();
        public Behavior pendingChild = null;
    }
}
