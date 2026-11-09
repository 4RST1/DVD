using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public GameObject NextLevel;
    public int Speed;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
    }

    void Update()
    {
        transform.position = transform.right * Speed * Time.deltaTime;
    }
}
