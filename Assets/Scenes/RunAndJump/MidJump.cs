using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidJump : MonoBehaviour
{
    private GameController _gameController;

    void Start()
    {
        _gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == null) return;

        other.attachedRigidbody.velocity = Vector3.zero;

        //_gameController.SwapGravity();
    }
}
