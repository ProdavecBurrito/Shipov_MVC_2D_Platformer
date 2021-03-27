using Shipov_Platformer_MVC;
using System;

namespace Shipov_QuestSystem
{
    public sealed class Quest : IQuest
    {
        public event EventHandler<IQuest> Completed;

        private readonly BaseQuestObjectView _view;
        private readonly IQuestModel _model;
        private readonly QuestUI _questUI;
        public bool IsCompleted { get; private set; }

        private bool _active;

        public Quest(BaseQuestObjectView view, IQuestModel model, QuestUI questUI)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
            _questUI = questUI != null ? questUI : throw new ArgumentNullException(nameof(questUI));
        }

        private void OnContact(LevelObjectView questObject)
        {
            var completed = _model.TryComplete(questObject.gameObject);
            if (completed)
            {
                Complete();
            }
        }

        private void Complete()
        {
            if (!_active)
            {
                return;
            }
            _questUI.ShowQuestUI(_view.FinishedQuestText);
            _active = false;
            IsCompleted = true;
            _view.OnLevelObjectContact -= OnContact;
            _view.ProcessComplete();
            OnCompleted();
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this, this);
        }

        public void Reset()
        {
            if (_active)
            {
                return;
            }
            _questUI.ShowQuestUI(_view.StartQuestText);
            _active = true;
            IsCompleted = false;
            _view.OnLevelObjectContact += OnContact;
            _view.ProcessActivate();
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnContact;
        }
    }
}

