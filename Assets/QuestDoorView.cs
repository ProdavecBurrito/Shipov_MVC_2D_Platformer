using Shipov_Platformer_MVC;
using UnityEngine;

namespace Shipov_QuestSystem
{
    public class QuestDoorView : LevelObjectView
    {
		public void ProcessComplete()
		{
			Debug.Log("kek");
			gameObject.SetActive(false);
		}
	}
}
