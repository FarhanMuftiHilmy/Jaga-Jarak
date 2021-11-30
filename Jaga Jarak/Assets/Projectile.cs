using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject[] patients;

    private Vector2 target;

    private Vector2 random_target;

    public GameObject object_target;

    public float speed;

    private AudioSource[] sounds;
    private AudioSource sound1;
    private AudioSource sound2;

    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        /*
        patients = GameObject.FindGameObjectsWithTag("Patient");

        int rand = Random.Range(0, patients.Length);
        target = patients[rand].transform.position;
        */

        
        if (object_target.CompareTag("Patient"))
        {
            patients = GameObject.FindGameObjectsWithTag("Patient");
            int rand = Random.Range(0, patients.Length);
            target = patients[rand].transform.position;
        } else if (object_target.CompareTag("Patient-Shooter"))
        {
            target = object_target.transform.position;
        }
        sounds = GetComponents<AudioSource>();
        sound1 = sounds[0];
        sound2 = sounds[1];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        /*
        if(Vector2.Distance(transform.position, target) < 0.2f)
        {
            Destroy(gameObject);
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Patient" || other.tag == "Patient-Shooter")
        {
            //sound1.Play();
            gm.GameOver();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    } 
}
