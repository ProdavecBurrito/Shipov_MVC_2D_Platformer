using UnityEngine;
using UnityEditor;

public class Test : MonoBehaviour
{
    public Vector2 Vector2;
    public Vector3 Vector3;

    private void Awake()
    {
        Debug.Log(Vector2.magnitude);
        Debug.Log(Vector3.magnitude);
    }
}
