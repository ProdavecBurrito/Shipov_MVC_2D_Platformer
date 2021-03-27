using System;

namespace Shipov_QuestSystem
{
    public interface IQuestStory : IDisposable
    {
        bool IsDone { get; }
    }
}

