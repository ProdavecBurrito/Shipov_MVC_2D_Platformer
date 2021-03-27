using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class Timer
    {
        public float CurrentTime { get; private set; }
        public float EndTime { get; set; }
        public bool IsOn;

        public void Init(float endtime)
        {
            EndTime = endtime;
            IsOn = true;
        }

        public void Reset()
        {
            CurrentTime = 0.0f;
            IsOn = false;
        }

        public bool IsTimeOver()
        {
            if (CurrentTime < EndTime)
            {
                return false;
            }
            return true;
        }

        public void CountTime()
        {
            if (IsOn)
            {
                if (CurrentTime < EndTime)
                {
                    CurrentTime += Time.deltaTime;
                }
                else
                {
                    Reset();
                }
            }
        }
    }
}
