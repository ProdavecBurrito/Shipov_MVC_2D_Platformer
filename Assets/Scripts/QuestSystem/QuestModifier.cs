using System.Collections.Generic;
using UnityEngine;
using System;

namespace Shipov_QuestSystem
{
    public class QuestModifier : IDisposable
    {
        private BaseQuestObjectView _baseQuestView;
        private QuestParticleSystem _questParticleSystem;
        private List<GameObject> _removingObjects;
        private QuestDoorView _questDoorView;
        private bool _activateOnStart;

        public bool ActivateOnStart => _activateOnStart;

        public QuestModifier(BaseQuestObjectView baseQuestObjectView, QuestParticleSystem questParticleSystem, QuestDoorView questDoorView, bool activateOnStart)
        {
            _baseQuestView = baseQuestObjectView;
            _activateOnStart = activateOnStart;
            _questParticleSystem = questParticleSystem;
            _questDoorView = questDoorView;
        }

        public void ModifyQuest()
        {
            if (_activateOnStart)
            {
                _baseQuestView.OnComplite += _questParticleSystem.StopParticleSystem;
                _baseQuestView.OnComplite += _questDoorView.ProcessComplete;
                _baseQuestView.OnStart += _questParticleSystem.PlayParticleSystem;
            }
            else
            {
                _baseQuestView.OnComplite += _questParticleSystem.PlayParticleSystem;
                _baseQuestView.OnStart += _questParticleSystem.StopParticleSystem;
            }
        }

        public void AddRemovingObject(GameObject gameObject)
        {
            _removingObjects.Add(gameObject);
        }

        public void RemoveRemovingObject(GameObject gameObject)
        {
            if (_removingObjects.Contains(gameObject))
            {
                _removingObjects.Remove(gameObject);
            }
        }

        public void RemoveObjects()
        {
            Debug.Log(7);
            foreach (var item in _removingObjects)
            {
                item.SetActive(false);
            }
        }

        public void Dispose()
        {
            if (_activateOnStart)
            {
                _baseQuestView.OnComplite -= _questParticleSystem.StopParticleSystem;
                _baseQuestView.OnComplite -= _questDoorView.ProcessComplete;
                _baseQuestView.OnStart -= _questParticleSystem.PlayParticleSystem;
            }
            else
            {
                _baseQuestView.OnComplite -= _questParticleSystem.PlayParticleSystem;
                _baseQuestView.OnStart -= _questParticleSystem.StopParticleSystem;
            }
        }
    }
}
