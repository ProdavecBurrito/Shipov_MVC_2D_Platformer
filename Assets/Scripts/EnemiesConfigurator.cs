using Pathfinding;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class EnemiesConfigurator : MonoBehaviour
    {
        [Header("Simple AI")]
        [SerializeField] private AIConfig _simplePatrolAIConfig;
        [SerializeField] private LevelObjectView _simplePatrolAIView;

        [Header("Stalker AI")]
        [SerializeField] private AIConfig _stalkerAIConfig;
        [SerializeField] private LevelObjectView _stalkerAIView;
        [SerializeField] private Seeker _stalkerAISeeker;
        [SerializeField] private Transform _stalkerAITarget;

        #region Fields

        private PatrolingAI _patrolingAI;
        private StalkerAI _stalkerAI;

        #endregion


        #region Unity methods

        private void Start()
        {
            _patrolingAI = new PatrolingAI(_simplePatrolAIView, new PatrolingAIModel(_simplePatrolAIConfig));

            _stalkerAI = new StalkerAI(_stalkerAIView, new StalkerAIModel(_stalkerAIConfig), _stalkerAISeeker, _stalkerAITarget);
            InvokeRepeating(nameof(RecalculateAIPath), 0.0f, 1.0f);
        }

        private void FixedUpdate()
        {
            if (_patrolingAI != null) _patrolingAI.FixedUpdateTick();
            if (_stalkerAI != null) _stalkerAI.FixedUpdate();
        }

        #endregion

        #region Methods

        private void RecalculateAIPath()
        {
            _stalkerAI.RecalculatePath();
        }

        #endregion

    }
}
