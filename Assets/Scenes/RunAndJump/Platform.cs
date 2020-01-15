using UnityEngine;

public class Platform : MonoBehaviour
{
    private GameController _gameController;

    public GameObject PlatformPrefab;

    public GameObject JumpPad;

    void Start()
    {
        _gameController = FindObjectOfType<GameController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // ball landed on us
        SpawnAnotherPlatform();
    }

    public void SetSize(float x, float z, float rotation)
    {
        transform.localScale = new Vector3(x, 1, z);
        transform.localPosition = new Vector3(0, -5, transform.localScale.z * 0.5f);
        transform.parent.transform.localRotation = Quaternion.Euler(0, 0, rotation);

        JumpPad.transform.localScale = new Vector3(x, 5, 1);
        JumpPad.transform.localPosition = new Vector3(0, transform.localPosition.y, z);
    }

    void SpawnAnotherPlatform()
    {
        var inst = Instantiate(PlatformPrefab, transform.parent.parent.transform);
        inst.name = "Platform";

        _gameController.SetPlatform(inst);

        var pos = JumpPad.transform.position.z;

        inst.transform.position = new Vector3(0, 0, pos + 120);

        var rotation = Random.Range(0, 359);

        var platformComponent = inst.GetComponentInChildren<Platform>();

        platformComponent.SetSize(transform.localScale.x * 0.8f, transform.localScale.z * 0.8f, rotation);
    }

}
