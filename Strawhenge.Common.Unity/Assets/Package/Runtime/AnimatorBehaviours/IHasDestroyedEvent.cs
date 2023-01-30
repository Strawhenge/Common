using System;

namespace Strawhenge.Common.Unity.AnimatorBehaviours
{
    public interface IHasDestroyedEvent
    {
        event Action Destroyed;
    }
}