using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject spawn;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject player;
    public new GameObject camera;
    public GameObject camerapoint;

    public bool dead = false;
    public bool win;
    public bool lose2;
    public bool lose1;
    public bool lvl1 = true;
    public bool lvl2 = false;
    private int health = 3;
    private int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        dead = true;
        Ragdoll(false);
        print(" LEVEL 1-- Are You Ready?--   GO   --- You have  3 Healt");

    }

    // Update is called once per frame
    void Update()
    {
        #region --------------YÜRÜME--------------
        if (dead == false && Input.GetMouseButton(0))
        {
            GetComponent<Animator>().SetBool("kosma", true);
            transform.Translate(-transform.right * speed * 3 * Time.deltaTime);
        }

        else if (dead == false && Input.GetMouseButton(1))
        {
            GetComponent<Animator>().SetBool("kosma", true);
            transform.Translate(transform.right * speed * 3 * Time.deltaTime);
        }

        else if (dead == false && Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Animator>().SetBool("walking", true);
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else if (dead == false && Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Animator>().SetBool("walking", true);
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        else
        {
            GetComponent<Animator>().SetBool("kosma", false);
            GetComponent<Animator>().SetBool("walking", false);
        }
        #endregion
        if (Input.GetKeyDown(KeyCode.R))
        {
            Ragdoll(false);

            if (lose2 == true)
            {
                print(" LEVEL 2-- Are You Ready?--   GO   --- You have  3 Healt");
                player.transform.rotation = spawn2.transform.rotation;
                transform.position = spawn2.transform.position;
                player.transform.position = spawn2.transform.position;

                lose2 = false;
                dead = false;
            }
            else if (lose1 == true)
            {
                player.transform.rotation = spawn.transform.rotation;
                transform.position = spawn.transform.position;
                player.transform.position = spawn.transform.position;
                print(" LEVEL 1-- Are You Ready?--   GO   --- You have  3 Healt");

                lose1 = false;
                dead = false;
            }

        }
        else if (Input.GetKeyDown(KeyCode.B)) 
        {
            Ragdoll(false);

        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {



            print(" LEVEL 2-- Are You Ready?--   GO   --- You have  3 Healt");
            player.transform.rotation = spawn2.transform.rotation;
            player.transform.position = spawn2.transform.position;

            camera.transform.rotation = camerapoint.transform.rotation;
            camera.transform.position = camerapoint.transform.position;

        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            dead = false;
            if (lvl1 == true)
            {

                health = 3;

                transform.position = spawn.transform.position;
                transform.rotation = spawn.transform.rotation;
                lvl1 = false;
                win = false;
            }


            else if (win == true)
            {
                print(" LEVEL 2-- Are You Ready?--   GO   --- You have  3 Healt");
                health = 3;

                transform.position = spawn2.transform.position;
                transform.rotation = spawn2.transform.rotation;

                dead = false;
                win = false;
            }




        }

        else if (Input.GetKeyDown(KeyCode.Y))
        {



            print(" LEVEL 2-- Are You Ready?--   GO   --- You have  3 Healt");
            health = 3;

            transform.position = spawn2.transform.position;
            transform.rotation = spawn2.transform.rotation;

            dead = false;
            win = false;





        }


    }

    public void Ragdoll(bool active)
    {
        GetComponent<Animator>().enabled = !active;
        GetComponent<Collider>().enabled = !active;

        Rigidbody[] rigidbodies = transform.GetChild(0).GetComponentsInChildren<Rigidbody>();
        Collider[] colliders = transform.GetChild(0).GetComponentsInChildren<Collider>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = !active;
        }
        foreach (Collider collider in colliders)
        {
            collider.enabled = active;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trap")
        {
            if (health > 1)
            {

                health -= damage;
                transform.position = spawn.transform.position;
                print(" **TRY AGAIN**     You have " + health + " healt ");

            }

            else if (health <= 1)
            {
                Ragdoll(true);
                print("!!! GAME OVER !!!  Do you wanna Try again Press B...");
                health = 3;
                lose1 = true;
                dead = true;
            }
        }
        else if (other.tag == "Finish")
        {
            dead = true;
            health = 3;

            transform.position = spawn3.transform.position;
            transform.rotation = spawn3.transform.rotation;

            win = true;
        }


        if (other.tag == "Trap2")
        {
            if (health > 1)
            {

                health -= damage;
                transform.position = spawn2.transform.position;
                print(" **TRY AGAIN**     You have " + health + " healt ");

            }

            else if (health <= 1)
            {
                Ragdoll(true);
                print("!!! GAME OVER !!!  Do you Wanna try again Press R...");
                health = 3;
                lose2 = true;
                dead = true;


            }
        }
        else if (other.tag == "Finish2")
        {

            print(" **WELL DONE**    Can you pass next level ? ");
            win = true;
        }




    }
}
