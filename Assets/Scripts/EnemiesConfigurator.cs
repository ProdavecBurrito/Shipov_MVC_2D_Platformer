using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class EnemiesConfigurator : MonoBehaviour
    {
        [Header("Stalker AI")]
        [SerializeField] private AIConfig _stalkerAIConfig;
        [SerializeField] private LevelObjectView _stalkerAIView;
        [SerializeField] private Seeker _stalkerAISeeker;
        [SerializeField] private Transform _stalkerAITarget;

        [Header("Protector AI")]
        [SerializeField] private LevelObjectView _protectorAIView;
        [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;
        [SerializeField] private AIPatrolPath _protectorAIPatrolPath;
        [SerializeField] private LevelTrigger _protectedZoneTrigger;
        [SerializeField] private Transform[] _protectorWaypoints;

        private StalkerAI _stalkerAI;
        private PatrolingAI _protectorAI;
        private ProtectedZone _protectedZone;

        private void Start()
        {
            _stalkerAI = new StalkerAI(_stalkerAIView, new StalkerAIModel(_stalkerAIConfig), _stalkerAISeeker, _stalkerAITarget);
            InvokeRepeating(nameof(RecalculateAIPath), 0.0f, 1.0f);

            _protectorAI = new PatrolingAI(_protectorAIView, new PatrolingAIModel(_protectorWaypoints), _protectorAIDestinationSetter, _protectorAIPatrolPath);
            _protectorAI.Init();

            _protectedZone = new ProtectedZone(_protectedZoneTrigger, new List<IProtector> { _protectorAI });
            _protectedZone.Init();
        }

        private void FixedUpdate()
        {
            if (_stalkerAI != null) _stalkerAI.FixedUpdate();
        }

        private void OnDestroy()
        {
            _protectorAI.Deinit();
            _protectedZone.Deinit();
        }

        private void RecalculateAIPath()
        {
            _stalkerAI.RecalculatePath();
        }
    }
}
