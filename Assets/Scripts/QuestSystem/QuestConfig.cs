using UnityEngine;
using System.Collections.Generic;

namespace Shipov_QuestSystem
{
[CreateAssetMenu(menuName = "Create QuestConfig", fileName = "QuestConfig", order = 0)]
    public class QuestConfig : ScriptableObject
    {
        public int QuestID;
        public string StartQuestText;
        public string FinishedQuestText;
        public List<GameObject> RemovingObjects;
        public QuestType QuestType;
    }
}
