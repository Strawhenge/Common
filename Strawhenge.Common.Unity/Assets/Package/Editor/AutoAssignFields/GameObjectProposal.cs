using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    class GameObjectProposal
    {
        public GameObjectProposal(GameObject gameObject, IReadOnlyList<ScriptProposal> scriptProposals)
        {
            GameObject = gameObject;
            ScriptProposals = scriptProposals;
        }

        public GameObject GameObject { get; }

        public IReadOnlyList<ScriptProposal> ScriptProposals { get; }
    }
}