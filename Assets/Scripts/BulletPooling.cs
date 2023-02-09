using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    public List<GameObject> poolBullet;
    public GameObject bulletPrefab;

    //public GameObject GetPoolObject()
    //{
    //   if(poolBullet.Count == 0)
    //    {
    //        GameObject go = Instantiate(bulletPrefab);
    //        go.gameObject.SetActive(false);
    //        poolBullet.Add(go);
    //    }
    //}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
