using Shipov_Platformer_MVC;
using UnityEngine;

namespace Shipov_QuestSystem
{
    public abstract class BaseQuestObjectView : LevelObjectView
    {
        public int Id => _id;
        public string StartQuestText => _startQuestText;
        public string FinishedQuestText => _finishedQuestText;

        [SerializeField] private int _id;
        [SerializeField] private string _startQuestText;
        [SerializeField] private string _finishedQuestText;

        public abstract void ProcessComplete();

        public abstract void ProcessActivate();
    }
}
