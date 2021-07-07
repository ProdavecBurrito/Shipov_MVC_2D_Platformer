using UnityEngine;
using UnityEngine.UI;

namespace Shipov_QuestSystem
{
    public class QuestUI : MonoBehaviour
    {
        private Text _text;
        private Animator _animator;

        private void Awake()
        {
            _text = GetComponentInChildren<Text>();
            _animator = GetComponent<Animator>();
        }

        public void ShowQuestUI(string text)
        {
            _text.text = text;
            _animator.Play("QuestAnim");
        }
    }
}
