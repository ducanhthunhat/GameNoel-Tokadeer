using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Transform firePoin;
    public GameObject snowBall;
    private float TimeBullet;
    public float timeBullet = 0.2f;

   
    void Update()
    {
        TimeBullet -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && TimeBullet < 0)
        {
            Fire();  
        }
    }

    private void Fire()
    {
        Instantiate(snowBall, firePoin.position, firePoin.rotation);
        TimeBullet = timeBullet;

    }


}


