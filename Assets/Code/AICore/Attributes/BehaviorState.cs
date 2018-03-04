using System;

namespace AICore.Attributes
{
    public class BehaviorState : Attribute
    {
        public AIState State;

        public BehaviorState(AIState state)
        {
            State = state;
        }
    }
}
