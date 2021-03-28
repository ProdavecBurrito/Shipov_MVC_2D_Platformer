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
        private bool _activateOnStart;

        public bool ActivateOnStart => _activateOnStart;

        public QuestModifier(BaseQuestObjectView baseQuestObjectView, QuestParticleSystem questParticleSystem, bool activateOnStart)
        {
            _baseQuestView = baseQuestObjectView;
            _activateOnStart = activateOnStart;
            _questParticleSystem = questParticleSystem;
        }

        public void ModifyQuest()
        {
            if (!_activateOnStart)
            {
                _baseQuestView.OnComplite += _questParticleSystem.PlayParticleSystem;
                _baseQuestView.OnStart += _questParticleSystem.StopParticleSystem;
            }
            else
            {
                _baseQuestView.OnComplite += _questParticleSystem.StopParticleSystem;
                _baseQuestView.OnStart += _questParticleSystem.PlayParticleSystem;
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
            foreach (var item in _removingObjects)
            {
                item.SetActive(false);
            }
        }

        public void Dispose()
        {
            if (!_activateOnStart)
            {
                _baseQuestView.OnComplite -= _questParticleSystem.PlayParticleSystem;
                _baseQuestView.OnStart -= _questParticleSystem.StopParticleSystem;
            }
            else
            {
                _baseQuestView.OnComplite -= _questParticleSystem.StopParticleSystem;
                _baseQuestView.OnStart -= _questParticleSystem.PlayParticleSystem;
            }
        }
    }
}
