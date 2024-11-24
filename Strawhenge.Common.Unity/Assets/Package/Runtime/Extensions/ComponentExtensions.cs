using System;
using UnityEngine;

namespace Strawhenge.Common.Unity
{
    public static class ComponentExtensions
    {
        public static T GetOrAddComponent<T>(this Component component) where T : Component
        {
            if (component.TryGetComponent<T>(out var addedComponent))
                return addedComponent;

            return component.AddComponent<T>();
        }

        public static T GetOrAddComponent<T>(this Component component, Action<Component> callback) where T : Component
        {
            var result = component.GetOrAddComponent<T>();
            callback(result);
            return result;
        }

        public static T AddComponent<T>(this Component component) where T : Component
        {
            return component.gameObject.AddComponent<T>();
        }

        public static T AddComponent<T>(this Component component, Action<Component> callback) where T : Component
        {
            var result = component.AddComponent<T>();
            callback(result);
            return result;
        }
    }
}