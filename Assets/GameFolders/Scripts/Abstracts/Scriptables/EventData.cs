using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Scriptables
{
    [CreateAssetMenu(fileName = "EventData", menuName = "Data/Event Data")]
    public class EventData : ScriptableObject
    {
        public System.Action OnSoundButton { get; set; }
        public System.Action OnSetMusic { get; set; }
        public System.Action<bool> OnMusicStop { get; set; }
        public System.Action OnChangeGamePlayState { get; set; }
        public System.Action OnGameOverCondition { get; set; }
        public System.Action OnWinCondition { get; set; }
        public System.Action OnDead { get; set; }
    }
}
