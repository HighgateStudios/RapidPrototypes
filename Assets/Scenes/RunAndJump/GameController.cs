using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject PlatformPrefab;

    private GameObject _CurrentPlatform;
    public GameObject Ball;
    public float? InputPercentage = null;

    public float RotateSpeed = 50f;

    void Start()
    {
        var map = GameObject.Find("Map");
        var inst = Instantiate(PlatformPrefab, map.transform);
        inst.name = "init";
        var platformComponent = inst.GetComponentInChildren<Platform>();
        platformComponent.SetSize(5, 200, 0);

    }

    public void SetPlatform(GameObject platform)
    {
        _CurrentPlatform = platform;
    }

    void FixedUpdate()
    {
        if (!InputPercentage.HasValue) return;

        if (_CurrentPlatform == null) return;

        _CurrentPlatform.transform.Rotate(0, 0, InputPercentage.Value * -RotateSpeed);
    }

    void Update()
    {
        if (Ball.transform.position.y < -100f)
        {
            Application.Quit();
        }
    }
}
