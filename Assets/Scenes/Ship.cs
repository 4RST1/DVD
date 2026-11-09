using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;

public class Ship : MonoBehaviour
{


    public float Speed, Augmentation;

    private Vector3 MousPos, direction;


    private void Start()
    {

    }
    void Update()
    {

        Vector3 NewMousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        NewMousPos.z = 0;


        if (MousPos == NewMousPos)
        {
            transform.position += direction;
        }
        else
        {

            MousPos = NewMousPos;

            LookAtMouse();

            direction = (Speed * Time.deltaTime * (MousPos - transform.position).normalized);
            transform.position += direction;

        }

        Vector3 screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        if (transform.position.x > screenSize.x / 2)
        {
            transform.position = new Vector3(-screenSize.x / 2, transform.position.y, 0);
            direction = (Speed * Time.deltaTime * (MousPos - transform.position).normalized);
            LookAtMouse();
        }
        if (transform.position.y > screenSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, -screenSize.y / 2, 0);
            direction = (Speed * Time.deltaTime * (MousPos - transform.position).normalized);
            LookAtMouse();
        }

        if (transform.position.x < -screenSize.x / 2)
        {
            transform.position = new Vector3(screenSize.x / 2, transform.position.y, 0);
            direction = (Speed * Time.deltaTime * (MousPos - transform.position).normalized);
            LookAtMouse();
        }
        if (transform.position.y < -screenSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, screenSize.y / 2, 0);
            direction = (Speed * Time.deltaTime * (MousPos - transform.position).normalized);
            LookAtMouse();  
        }

        //Collision
        foreach (Asteroid t in FindObjectsByType<Asteroid>())
        {
            if ((t.transform.position.x - transform.position.x) t.)
        }


    }
        void LookAtMouse()
        {
            float opposite = transform.position.y - MousPos.y;

            float adjacent = transform.position.x - MousPos.x;


            float alpha = 180 - Mathf.Atan2(opposite, adjacent) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -alpha);

        }
        
    
}
