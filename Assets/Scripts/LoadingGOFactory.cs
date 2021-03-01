using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class LoadingGOFactory : IFactory
    {
        public GameObject Create(string objectLocation)
        {
            var instance = GameObject.Instantiate(Resources.Load<GameObject>(objectLocation));
            return instance;
        }

        public GameObject Create(string objectLocation, Vector3 vector)
        {
            var instance = GameObject.Instantiate(Resources.Load<GameObject>(objectLocation), vector, Quaternion.identity);
            return instance;
        }

        public GameObject Create(string objectLocation, Vector3 vector, Quaternion quaternion)
        {
            var instance = GameObject.Instantiate(Resources.Load<GameObject>(objectLocation), vector, quaternion);
            return instance;
        }
    }
}
