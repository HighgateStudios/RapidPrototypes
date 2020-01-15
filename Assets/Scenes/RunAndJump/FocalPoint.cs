using UnityEditor;
using UnityEngine;

public class FocalPoint : MonoBehaviour
{
    public float Speed;

    public bool RollEnabled = false;

    void Start()
    {
        Invoke("ReleaseBall", 2.0f);
    }

    void ReleaseBall()
    {
        RollEnabled = true;
    }

    void FixedUpdate()
    {
        if (!RollEnabled) return;

        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }
}
