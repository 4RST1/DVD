using TMPro;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public Asteroid NextLevel;
    public float Speed;
    private Ship Player;


    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
        Player = FindAnyObjectByType<Ship>();
        
    }

    void Update()
    {
        transform.position += transform.right * Speed * Time.deltaTime;

        //Collision
        Vector2 Extents = Player.GetComponent<SpriteRenderer>().bounds.extents * 0.7f;
        Vector2 AsteroidExtents = GetComponent<SpriteRenderer>().bounds.extents * 0.7f;
        if (!((Player.transform.position.x - Extents.x > transform.position.x + AsteroidExtents.x ||
               Player.transform.position.x + Extents.x < transform.position.x - AsteroidExtents.x)
              ||
              (Player.transform.position.y - Extents.y > transform.position.y + AsteroidExtents.y ||
               Player.transform.position.y + Extents.y < transform.position.y - AsteroidExtents.y)))
        {
            FindAnyObjectByType<Ship>().Loose();
        }
        foreach (ShootBehavour Shoot in FindObjectsByType<ShootBehavour>())
        {
            if (Shoot.transform.position.x - Shoot.GetComponent<SpriteRenderer>().bounds.extents.x > transform.position.x - GetComponent<SpriteRenderer>().bounds.extents.x &&
                Shoot.transform.position.x + Shoot.GetComponent<SpriteRenderer>().bounds.extents.x < transform.position.x + GetComponent<SpriteRenderer>().bounds.extents.x &&
                Shoot.transform.position.y - Shoot.GetComponent<SpriteRenderer>().bounds.extents.y > transform.position.y - GetComponent<SpriteRenderer>().bounds.extents.y &&
                Shoot.transform.position.y + Shoot.GetComponent<SpriteRenderer>().bounds.extents.y < transform.position.y + GetComponent<SpriteRenderer>().bounds.extents.y)
            {
                if (NextLevel != null)
                {
                    // Break
                    Instantiate(NextLevel, transform.position, transform.rotation);
                    Instantiate(NextLevel, transform.position, transform.rotation);
                    Destroy(Shoot.gameObject);
                    Destroy(gameObject);

                }
                else
                {
                    Destroy(Shoot.gameObject);
                    Destroy(gameObject);
                }
            }

        }


        //Go Back to screen if go out
        Vector3 screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        if (transform.position.x > screenSize.x / 2)
        {
            transform.position = new Vector3(-screenSize.x / 2, transform.position.y, 0);
        }
        if (transform.position.y > screenSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, -screenSize.y / 2, 0);
        }

        if (transform.position.x < -screenSize.x / 2)
        {
            transform.position = new Vector3(screenSize.x / 2, transform.position.y, 0);
        }
        if (transform.position.y < -screenSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, screenSize.y / 2, 0);
        }
    }


}
