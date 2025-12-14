using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    class FieldProposal
    {
        public string FieldName { get; set; }

        public Component Value { get; set; }

        public bool Accept { get; set; } = true;
    }
}