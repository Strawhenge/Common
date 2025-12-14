using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    class ScriptProposal
    {
        public ScriptProposal(MonoBehaviour script, IReadOnlyList<FieldProposal> fieldProposals)
        {
            Script = script;
            FieldProposals = fieldProposals;
        }

        public MonoBehaviour Script { get; }

        public IReadOnlyList<FieldProposal> FieldProposals { get; }
    }
}