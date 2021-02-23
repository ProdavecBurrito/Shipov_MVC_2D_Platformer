using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class InputController : IUpdate
    {
        private const KeyCode _jump = KeyCode.Space;

        private PlayerModel _playerModel;
        private PlayerView _playerView;

        public InputController(PlayerModel playerModel, PlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
        }

        public void UpdateTick()
        {
            _playerModel.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0.0f, _playerView.Speed);

            if (Input.GetKeyDown(_jump))
            {
                _playerModel.Jump(_playerView.JumpForce);
            }
        }
    }
}
