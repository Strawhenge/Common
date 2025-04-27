using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

namespace Strawhenge.Common.Unity.Tests
{
    public class InvokeAsSoonAsTests
    {
        [UnityTest]
        public IEnumerator When_condition_is_already_true_should_invoke()
        {
            var monoBehaviour = new GameObject(nameof(InvokeAsSoonAsTests))
                .AddComponent<InvokeAsSoonAsTestsScript>();

            var gameObjectToDestroy = new GameObject("Destroy this.");

            monoBehaviour.InvokeAsSoonAs(
                () => true,
                () => Object.Destroy(gameObjectToDestroy));

            yield return new WaitForEndOfFrame();

            Assert.IsNull(gameObjectToDestroy);
        }

        [UnityTest]
        public IEnumerator When_condition_is_false_should_invoke_later_when_condition_is_true()
        {
            var monoBehaviour = new GameObject(nameof(InvokeAsSoonAsTests))
                .AddComponent<InvokeAsSoonAsTestsScript>();

            var gameObjectToDestroy = new GameObject("Destroy this.");
            bool shouldDestroyGameObject = false;

            // ReSharper disable once AccessToModifiedClosure
            monoBehaviour.InvokeAsSoonAs(
                () => shouldDestroyGameObject,
                () => Object.Destroy(gameObjectToDestroy));

            for (int i = 0; i < 5; i++)
                yield return new WaitForEndOfFrame();

            Assert.IsNotNull(gameObjectToDestroy);

            shouldDestroyGameObject = true;

            yield return new WaitForEndOfFrame();

            Assert.IsNull(gameObjectToDestroy);
        }
    }
}