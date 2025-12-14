using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    class ProposedScriptFieldAssignments
    {
        public MonoBehaviour Script { get; set; }

        public ProposedFieldAssignment[] FieldAssignments { get; set; }
    }
}