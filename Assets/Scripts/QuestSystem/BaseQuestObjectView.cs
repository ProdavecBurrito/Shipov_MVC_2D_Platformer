using Shipov_Platformer_MVC;
using System;
using UnityEngine;

namespace Shipov_QuestSystem
{
    public abstract class BaseQuestObjectView : LevelObjectView
    {
        public event Action OnComplite;
        public event Action OnStart;
        public bool IsModified;

        public int Id => _id;

        public string StartQuestText;
        public string FinishedQuestText;

        [SerializeField] private int _id;

        public virtual void ProcessComplete()
        {
            OnComplite?.Invoke();
        }

        public virtual void ProcessActivate()
        {
            OnStart?.Invoke();
        }
    }
}
