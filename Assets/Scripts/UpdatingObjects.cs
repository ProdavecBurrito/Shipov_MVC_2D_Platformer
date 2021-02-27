using System.Collections.Generic;

namespace Shipov_Platformer_MVC
{
    public class UpdatingObjects <T>
    {
        private List<T> _updatingObjects;

        public int Count => _updatingObjects.Count;

        public UpdatingObjects()
        {
            _updatingObjects = new List<T>();
        }

        public void AddUpdatingObject(T update)
        {
            _updatingObjects.Add(update);
        }

        public void RemoveUpdatingObject(T update)
        {
            if (_updatingObjects.Contains(update))
            {
                _updatingObjects.Remove(update);
            }
        }

        public T this[int index]
        {
            get
            {
                return _updatingObjects[index];
            }
        }
    }
}
