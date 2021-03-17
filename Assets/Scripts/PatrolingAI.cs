using System;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class PatrolingAI : IFixedUpdate
    {
        private readonly LevelObjectView _view;
        private readonly PatrolingAIModel _model;

        public PatrolingAI(LevelObjectView view, PatrolingAIModel model)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
        }

        public void FixedUpdateTick()
        {
            var newVelocity = _model.CalculateVelocity(_view.CharacterTransform.position) * Time.fixedDeltaTime;
            _view.CharacterRigidbody.velocity = newVelocity;
        }

    }
}
