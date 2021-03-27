using UnityEngine;

namespace Shipov_QuestSystem
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}

