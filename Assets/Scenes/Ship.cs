using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;

public class Ship : MonoBehaviour
{


    public float BaseSpeed, Augmentation;

    private Vector3 MousPos, direction;

    [SerializeField] private ShootBehavour Shoot;
    [SerializeField] private GameObject Win, LoosePanel;

    private float Timer, Speed;

    private void Start()
    {
        Speed = BaseSpeed;
    }
    void Update()
    {

        //Verify if victory
        if (FindObjectsByType<Asteroid>().Length == 0)
        {
            Win.SetActive(true);
            Time.timeScale = 0;
        }

        //Shoot
        Timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Timer > 0.2f)
            {
                Timer = 0;
                Instantiate(Shoot, transform.position, transform.rotation);
            }
        }

        //Acceleration
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Speed += Augmentation * Time.deltaTime;
        }
        else
        {
                Speed = BaseSpeed;
        }


        //Make the ship move 
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

        //Go Back to screen if go out
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




    }


    //Loose 
    public void Loose()
    {
        LoosePanel.SetActive(true);
        Time.timeScale = 0;
    }

    //Set direction to mouse after Teleport 
        void LookAtMouse()
        {
            float opposite = transform.position.y - MousPos.y;

            float adjacent = transform.position.x - MousPos.x;


            float alpha = 180 - Mathf.Atan2(opposite, adjacent) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -alpha);

        }
        
    
}
