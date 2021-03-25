using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class ElevatorView : LevelObjectView
    {
        private SliderJoint2D _joint;
        private JointMotor2D _jointMotor;
        float keks;

        private void Awake()
        {
            _joint = GetComponent<SliderJoint2D>();
            _joint.useMotor = true;
            _jointMotor = _joint.motor;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("ElevatorTrigger"))
            {
                ChangeDirection();
            }
        }

        private void ChangeDirection()
        {
            _jointMotor.motorSpeed *= -1;
            _joint.motor = _jointMotor;
        }
    }
}
