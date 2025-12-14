using UnityEngine;

namespace Strawhenge.Common.Unity
{
    public class PlayerScript : MonoBehaviour
    {
        [SerializeField] EmotesScript _emotes;
        [SerializeField] InventoryScript _inventory;
        [SerializeField] LoggerScript _logger;
    }
}