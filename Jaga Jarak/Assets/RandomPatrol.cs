using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 targetPosition;

    public float minSpeed;
    public float maxSpeed;

    float speed;

    //private Animator ani;
    //bool isLeft = false;

    public float secondToMaxDif;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GetRandomPosition();
        //ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()  
    {
        if((Vector2)transform.position != targetPosition)
        {
            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed*Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }
    }

    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
       /*
        if(randomX <= 0)
        {
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }
        ani.SetBool("direction", isLeft);
        */
        return new Vector2(randomX, randomY);
    }


    float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondToMaxDif);
    }
}       
