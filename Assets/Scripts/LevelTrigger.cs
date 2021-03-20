using System;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class LevelTrigger : MonoBehaviour
    {
        public event EventHandler<GameObject> TriggerEnter;
        public event EventHandler<GameObject> TriggerExit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            TriggerEnter?.Invoke(this, other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            TriggerExit?.Invoke(this, other.gameObject);
        }


    }
}
