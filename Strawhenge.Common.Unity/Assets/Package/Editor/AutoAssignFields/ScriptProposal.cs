using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    class ScriptProposal
    {
        public MonoBehaviour Script { get; set; }

        public FieldProposal[] FieldProposals { get; set; }
    }
}