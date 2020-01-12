using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float m_Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * m_Speed * Time.deltaTime;
    }
}
