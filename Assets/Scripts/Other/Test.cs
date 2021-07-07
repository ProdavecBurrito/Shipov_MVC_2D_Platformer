using UnityEngine;
using UnityEditor;

public class Test : MonoBehaviour
{
#if UNITY_EDITOR


    protected void OnDrawGizmos()
    {
        
        Vector3 pos = transform.position + Vector3.down;

        Handles.color = new Color(1.0f, 0.0f, 1.0f, 0.3f);
        Handles.DrawSolidArc(pos, Vector3.down, transform.up, 90, 55);
        Handles.DrawSolidArc(pos, Vector3.down, transform.up, -90, 55);
    }

#endif
}
