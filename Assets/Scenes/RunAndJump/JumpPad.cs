using UnityEngine;

public class JumpPad : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == null) return;

        other.attachedRigidbody.AddForce(new Vector3(0, 500, 0));
    }
}
