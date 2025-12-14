using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    class ProposedFieldAssignment
    {
        public string Field { get; set; }

        public Component Match { get; set; }

        public bool Accept { get; set; } = true;
    }
}