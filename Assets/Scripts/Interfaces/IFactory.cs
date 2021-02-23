using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public interface IFactory
    {
        GameObject Create(string objectLocation);

        GameObject Create(string objectLocation, Vector3 vector);

        GameObject Create(string objectLocation, Vector3 vector, Quaternion quaternion);
    }
}
