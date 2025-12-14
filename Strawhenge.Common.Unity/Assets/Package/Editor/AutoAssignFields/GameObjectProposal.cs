using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    class GameObjectProposal
    {
        public GameObject GameObject { get; set; }

        public ScriptProposal[] ScriptProposals { get; set; }
    }
}