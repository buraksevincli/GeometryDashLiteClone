using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Scriptables
{
    [CreateAssetMenu(fileName = "EventData", menuName = "Data/Event Data")]
    public class EventData : ScriptableObject
    {
        public System.Action OnSoundButton { get; set; }
        public System.Action OnSetMusic { get; set; }
    }
}
