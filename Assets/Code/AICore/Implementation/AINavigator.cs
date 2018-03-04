namespace AICore.Implementation
{
    using AICore.Attributes;
    using AICore.Interfaces;
    using UnityEngine;

    [BehaviorState(AIState.Navigate)]
    public class AINavigator : MonoBehaviour, IAIBehavior, INavigator
    {
        private AIState currentState;

        public void WakeUp()
        {
        }

        public void Sleep()
        {
        }

        public void NavigateTo(Vector3 point)
        {
        }
    }
}
