using UnityEngine;

namespace Strawhenge.Common.Unity
{
    public static class AnimatorExtensions
    {
        public static void SetInteger(this Animator animator, AnimatorParameter parameter, int value) =>
            animator.SetInteger(parameter.Id, value);

        public static void SetFloat(this Animator animator, AnimatorParameter parameter, float value) =>
            animator.SetFloat(parameter.Id, value);

        public static void SetBool(this Animator animator, AnimatorParameter parameter, bool value) =>
            animator.SetBool(parameter.Id, value);

        public static void SetTrigger(this Animator animator, AnimatorParameter parameter) =>
            animator.SetTrigger(parameter.Id);

        public static void ResetTrigger(this Animator animator, AnimatorParameter parameter) =>
            animator.ResetTrigger(parameter.Id);
    }
}