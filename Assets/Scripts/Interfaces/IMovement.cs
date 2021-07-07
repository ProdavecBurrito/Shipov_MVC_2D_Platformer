namespace Shipov_Platformer_MVC
{
    public interface IMovement
    {
        void UpdateMovement(float x, float speed, bool isJump, float jumpForce);
        //void Move(float x, float speed);
        //void Jump(bool isJump, float jumpForce);
    }
}
