using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void SwapGravity()
    {
        var dir = Physics.gravity.y;
        Physics.gravity = new Vector3(0, dir * -1, 0);

        Debug.Log(Physics.gravity);
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
        if (Ball.transform.position.y < -50f)
        {
            SceneManager.LoadScene("RunAndJump");
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
