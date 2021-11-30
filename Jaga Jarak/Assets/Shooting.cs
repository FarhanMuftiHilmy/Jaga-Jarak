using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shotPos;

    public GameObject projectTile;

    public float timeBtwShot;

    public float startTimeBtwShot;

   
    // Update is called once per frame
    void Update()
    {
        if(timeBtwShot <= 0)
        {
            Instantiate(projectTile, shotPos.position, Quaternion.identity);
            timeBtwShot = startTimeBtwShot;
        }
        else
        {
            timeBtwShot -= Time.deltaTime;
        }

    }
}
