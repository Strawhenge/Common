using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Common
{
    public static class QueueExtensions
    {
        public static IEnumerable<T> DequeueAll<T>(this Queue<T> queue)
        {
            while (queue.Any())
                yield return queue.Dequeue();
        }
    }
}