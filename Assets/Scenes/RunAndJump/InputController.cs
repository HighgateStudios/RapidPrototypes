using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private GameController _gameController;

    private float? _lastPercentage = null;

    void Start()
    {
        _gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            _gameController.InputPercentage = null;
            _lastPercentage = null;
            return;
        }

        var x_perc = Input.mousePosition.x / Screen.width;

        if (!_lastPercentage.HasValue)
        {
            _lastPercentage = x_perc;

            return;
        }

        var diff = _lastPercentage - x_perc;

        _gameController.InputPercentage = diff;

        _lastPercentage = x_perc;
    }
}
