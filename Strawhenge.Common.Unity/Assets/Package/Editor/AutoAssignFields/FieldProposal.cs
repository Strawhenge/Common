using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    class FieldProposal
    {
        public FieldProposal(string fieldName, Component value)
        {
            FieldName = fieldName;
            Value = value;
        }

        public string FieldName { get; }

        public Component Value { get; }

        public bool Accept { get; set; } = true;
    }
}