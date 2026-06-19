using System.Linq;
using UnityEditor.Animations;

namespace Strawhenge.Common.Unity.Editor.Helpers
{
    public static class ParameterIdHelper
    {
        /// <summary>
        /// Returns the highest integer value of the supplied parameter used in the animator, plus 1.
        /// </summary>
        public static int Generate(AnimatorController animatorController, AnimatorParameter parameter)
        {
            var highestId = 0;

            foreach (var layer in animatorController.layers)
            {
                highestId = layer.stateMachine.defaultState.transitions
                    .SelectMany(x => x.conditions
                        .Where(y => y.parameter == parameter.Name)
                        .Select(y => (int)y.threshold))
                    .Prepend(highestId)
                    .Max();
            }

            return highestId + 1;
        }
    }
}