using UnityEngine;

public class ShootBehavour : MonoBehaviour
{



    [SerializeField] private float Speed;

    private void Start()
    {
        Invoke("Destroy", 3);
    }
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * Speed);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
