using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_ForwardSpeed;
    public float m_RotationSpeed;

    private GameObject activePipeSection;

    void Update()
    {
        MovePlayerForward();

        if (activePipeSection != null)
        {
            activePipeSection.transform.RotateAround(transform.position, transform.forward, Input.GetAxis("Horizontal") * m_RotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider pipe)
    {
        Debug.Log("Colliding with " + pipe.gameObject.name);
        activePipeSection = pipe.gameObject;
    }

    private void MovePlayerForward()
    {
        transform.position += transform.forward * m_ForwardSpeed * Time.deltaTime;
    }
}
