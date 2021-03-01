using System.Collections.Generic;

namespace Shipov_Platformer_MVC
{
    public class UpdatingObjects
    {
        private List<IUpdate> _updatingObjects;

        public int Count => _updatingObjects.Count;

        public UpdatingObjects()
        {
            _updatingObjects = new List<IUpdate>();
        }

        public void AddUpdatingObject(IUpdate update)
        {
            _updatingObjects.Add(update);
        }

        public void RemoveUpdatingObject(IUpdate update)
        {
            if (_updatingObjects.Contains(update))
            {
                _updatingObjects.Remove(update);
            }
        }

        public IUpdate this[int index]
        {
            get
            {
                return _updatingObjects[index];
            }
        }
    }
}
