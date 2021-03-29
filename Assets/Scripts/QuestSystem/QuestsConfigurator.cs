using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shipov_QuestSystem
{
    public class QuestsConfigurator : MonoBehaviour
    {
        [SerializeField] private QuestUI _questUI;
        [SerializeField] private QuestStoryConfig[] _questStoryConfigs;
        [SerializeField] private BaseQuestObjectView[] _questObjects;

        private List<IQuestStory> _questStories;

        private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories = new Dictionary<QuestType, Func<IQuestModel>>
        {
            { QuestType.Trigger, () => new CollisionQuestModel() },
            { QuestType.Switch, () => new CollisionQuestModel() },
        };

        private readonly Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactories = new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>
        {
            { QuestStoryType.Common, questCollection => new QuestStory(questCollection) },
        };



        private void Start()
        {
            _questStories = new List<IQuestStory>();
            foreach (var questStoryConfig in _questStoryConfigs)
            {
                _questStories.Add(CreateQuestStory(questStoryConfig));
            }
        }

        private IQuestStory CreateQuestStory(QuestStoryConfig config)
        {
            var quests = new List<IQuest>();
            foreach (var questConfig in config.quests)
            {
                var quest = CreateQuest(questConfig);
                if (quest == null)
                {
                    Debug.Log(1);
                    continue;
                }
                quests.Add(quest);
            }
            return _questStoryFactories[config.questStoryType].Invoke(quests);
        }

        private IQuest CreateQuest(QuestConfig config)
        {
            var questId = config.QuestID;
            var questView = _questObjects.FirstOrDefault(value => value.Id == config.QuestID);
            if (questView.IsModified) // мне кажется, весь этот кусок - это огромный костыль
            {
                var questModifier = new QuestModifier(questView, questView.GetComponent<QuestParticleSystem>(), true);
                questModifier.ModifyQuest();
                for (int i = 0; i < _questStoryConfigs.Length; i++)
                {
                    for (int j = 0; j < _questStoryConfigs[i].quests.Length; j++)
                    {
                        if (_questStoryConfigs[i].quests[j].QuestID == questView.Id)
                        {
                            foreach (var item in _questStoryConfigs[i].quests[j].RemovingObjects)
                            {
                                questModifier.AddRemovingObject(item);
                            }
                        }
                    }
                }
            }
            questView.StartQuestText = config.StartQuestText;
            questView.FinishedQuestText = config.FinishedQuestText;
            
            if (questView == null)
            {
                Debug.LogWarning($"QuestsConfigurator :: Start : Can't find view of quest {questId.ToString()}");
                return null;
            }

            if (_questFactories.TryGetValue(config.QuestType, out var factory))
            {
                var questModel = factory.Invoke();
                return new Quest(questView, questModel, _questUI);
            }

            Debug.LogWarning($"QuestsConfigurator :: Start : Can't create model for quest {questId.ToString()}");
            return null;
        }
    }
}
