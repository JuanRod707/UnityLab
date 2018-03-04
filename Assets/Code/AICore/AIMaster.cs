using System.Linq;
using AICore.Attributes;
using AICore.Interfaces;

namespace AICore
{
    using UnityEngine;

    public class AIMaster : MonoBehaviour
    {
        private AIState currentState;
        private IAIBehavior[] behaviors;

        void Initialize()
        {
            behaviors = GetComponents<IAIBehavior>();
        }
    }
}
