﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class enemyattack : MonoBehaviour
{
    public float maxditcance;
    public float cooldowntime;
    public Text healthtext;
    

    private Transform mytransform;
    public Transform target;
    public playerhealth ph; 
     
    // Start is called before the first frame update
    void Start()
    {
         
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mytransform = transform;
        maxditcance = 3;
        cooldowntime = 1;
       

       
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, mytransform.position);
        if (distance < maxditcance)
        {

           
            
        }
        if (cooldowntime > 0)
        {
            cooldowntime = cooldowntime * Time.deltaTime;
        }
    }
    void Ontriggerenter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (target == null)
            {
                target = target.transform;
                ph.currenthealth = ph.currenthealth - 50;
                healthtext.text = "current health: " + ph.currenthealth.ToString();
                Debug.Log("hit");

            }


        }

    }
}
