using UnityEngine;

namespace Shipov_QuestSystem
{
[CreateAssetMenu(menuName = "Create QuestConfig", fileName = "QuestConfig", order = 0)]
    public class QuestConfig : ScriptableObject
    {
        public int QuestID;
        public QuestType QuestType;
    }
}
