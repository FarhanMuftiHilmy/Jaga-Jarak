using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool gerak;
    Collider2D col;
    public AudioSource[] sounds;
    public AudioSource sound1;
    public AudioSource sound2;

    public GameObject selectionEffect;

    private GameManager gm;

    // Start is called before the first frame update
    void Start() 
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        col = GetComponent<Collider2D>();
        sounds = GetComponents<AudioSource>();
        sound1 = sounds[0];
        sound2 = sounds[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) // cek jika jari menyentuh layar
        {
            Touch touch = Input.GetTouch(0); //player hanya boleh menyentuh dengan sentuhan pertama
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if(col == touchedCollider)
                {
                    gerak = true;
                    Instantiate(selectionEffect, transform.position, Quaternion.identity); 
                    sound2.Play();
                }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                if (gerak)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            if(touch.phase == TouchPhase.Ended)
            {
                gerak = false;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Patient" || collision.tag == "Corona" || collision.tag == "Patient-Shooter")
        {
            sound1.Play();
            gm.GameOver();
            //Panel.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
