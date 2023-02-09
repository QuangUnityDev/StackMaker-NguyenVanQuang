using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick1 : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }
    private void Update()
    {
        
        //Debug.Log(int.Parse(readText.a[x, y]));
        //Debug.Log(player.transform.position);


        if (player.transform.position.x == transform.position.x && player.transform.position.z == transform.position.z)
        {
            Destroy(gameObject);
        }
    }

    }
