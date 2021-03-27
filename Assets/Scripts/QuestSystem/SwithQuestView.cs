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
            Debug.Log("1");
            CharacterSpriteRenderer.sprite = _compliteSprite;
        }

        public override void ProcessComplete()
        {
            CharacterSpriteRenderer.sprite = _startSprite;
        }
    }
}
