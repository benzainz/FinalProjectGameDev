using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 100) * Time.deltaTime, Space.World);
    }
}