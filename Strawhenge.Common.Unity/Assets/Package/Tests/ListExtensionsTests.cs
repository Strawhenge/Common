using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Strawhenge.Common.Unity.Tests
{
    public class ListExtensionsTests
    {
        [Test]
        public void RemoveDestroyed_should_remove_destroyed_GameObjects_from_list()
        {
            var myObject = new GameObject("Object to destroy");

            var list = new List<GameObject>()
            {
                new GameObject(),
                new GameObject(),
                myObject,
                new GameObject(),
                new GameObject(),
            };

            Object.DestroyImmediate(myObject);
            list.RemoveDestroyed();

            Assert.AreEqual(4, list.Count);
            CollectionAssert.DoesNotContain(list, myObject);
        }

        [Test]
        public void RemoveDestroyed_should_remove_objects_on_destroyed_GameObjects_from_list()
        {
            var myObject = new GameObject("Object to destroy");
            var myCollider = myObject.AddComponent<SphereCollider>();

            var list = new List<Collider>()
            {
                new GameObject().AddComponent<SphereCollider>(),
                new GameObject().AddComponent<SphereCollider>(),
                myCollider,
                new GameObject().AddComponent<SphereCollider>(),
                new GameObject().AddComponent<SphereCollider>(),
            };

            Object.DestroyImmediate(myObject);
            list.RemoveDestroyed();

            Assert.AreEqual(4, list.Count);
            CollectionAssert.DoesNotContain(list, myCollider);
        }
    }
}