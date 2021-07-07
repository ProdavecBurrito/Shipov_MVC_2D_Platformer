using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    [CreateAssetMenu(menuName = "QuestItemsConfig", fileName = "QuestItemsConfig", order = 0)]
    public class QuestItemsConfig : ScriptableObject
    {
        public int questId;
        public List<int> questItemIdCollection;
    }

}
