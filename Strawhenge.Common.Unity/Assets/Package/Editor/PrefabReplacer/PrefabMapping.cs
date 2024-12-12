using System;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    [Serializable]
    public class PrefabMapping
    {
        [SerializeField] GameObject _originalPrefab;
        [SerializeField] GameObject _replacementPrefab;

        internal GameObject OriginalPrefab => _originalPrefab;

        internal GameObject ReplacementPrefab => _replacementPrefab;
    }
}