using UnityEngine;

namespace Shipov_QuestSystem
{
    public class SwithQuestView : BaseQuestObjectView
    {
        public Sprite _startSprite;
        public Sprite _compliteSprite;

        private void Awake()
        {
            CharacterSpriteRenderer = GetComponent<SpriteRenderer>();
            CharacterSpriteRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
            _startSprite = CharacterSpriteRenderer.sprite;
        }

        public override void ProcessActivate()
        {
            base.ProcessActivate();
            CharacterSpriteRenderer.sprite = _startSprite;
        }

        public override void ProcessComplete()
        {
            base.ProcessComplete();
            CharacterSpriteRenderer.sprite = _compliteSprite;
        }
    }
}
