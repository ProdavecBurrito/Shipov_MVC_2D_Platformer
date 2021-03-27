using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class InputController : IUpdate
    {
        private const KeyCode _jump = KeyCode.Space;

        private IMovement _playerModel;
        private PlayerView _playerView;

        public InputController(IMovement playerModel, PlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
        }

        public void UpdateTick()
        {
            //_playerView.Timer.CountTime();
            _playerModel.UpdateMovement(Input.GetAxis("Horizontal"), _playerView.Speed, Input.GetKeyDown(_jump), _playerView.JumpForce);
        }
    }
}
