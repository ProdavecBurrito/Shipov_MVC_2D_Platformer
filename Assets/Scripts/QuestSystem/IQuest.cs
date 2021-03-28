using System;

namespace Shipov_QuestSystem
{
    public interface IQuest : IDisposable
    {
        event EventHandler<IQuest> Completed;
        bool IsCompleted { get; }
        void StartQuest();
    }
}
