using UnityEngine;

namespace Strawhenge.Common.Unity
{
    public class AnimatorParameter
    {
        public AnimatorParameter(string name)
        {
            Name = name;
            Id = Animator.StringToHash(name);
        }

        public string Name { get; }

        public int Id { get; set; }
    }
}