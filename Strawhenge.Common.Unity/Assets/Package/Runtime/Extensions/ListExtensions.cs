using System.Collections.Generic;

namespace Strawhenge.Common.Unity
{
    public static class ListExtensions
    {
        public static void RemoveDestroyed<T>(this IList<T> list) where T : UnityEngine.Object
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] == null)
                    list.RemoveAt(i);
            }
        }
    }
}