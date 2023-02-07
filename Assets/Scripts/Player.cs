using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 starPos;
    Vector2 endPos;
    bool isTouch;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private ReadText readText;
    public Transform posTarget;
    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
           int value =  int.Parse(readText.a[0, i]);        
           if(value == 3)
            {
                currentPosx = 0;
                currentPosz = i;
                transform.position = new Vector3(0f, transform.position.y, i);
                posTarget.position = transform.position;
            } 
        }             
    }
    private void Update()
    {
        numberChild = transform.childCount;
        Debug.Log(numberChild);
       
        //Debug.Log(transform.position);
        if (Input.GetMouseButtonDown(0))
        { 
            isTouch = true;
            starPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
        }
        if (isTouch)
        {
            endPos = Input.mousePosition;
        }
        
        Vector2 dir = new Vector2(endPos.x - starPos.x, endPos.y - starPos.y);
        float ange = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        //Debug.Log(ange);
        if (ange == 0) return;
        if (45 < ange && ange < 135)
        {
            if (posTarget.position == transform.position)
            {
                CheckBlock(1,0);               
            }
            if (isMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, posTarget.position, 10 * Time.deltaTime);
            }                        
            //Di chuyen Right        
        }
        else if (-135 < ange && ange < -45)
        {
            if (posTarget.position == transform.position)
            {
                CheckBlock(-1, 0);
            }
            if (isMove)
                transform.position = Vector3.MoveTowards(transform.position, posTarget.position, 10 * Time.deltaTime);
            //Di chuyen trai          
        }
        else if (-45 < ange && ange < 45)
        {
            if (posTarget.position == transform.position)
            {
                CheckBlock(0, 1);
            }
            if (isMove)
                transform.position = Vector3.MoveTowards(transform.position, posTarget.position, 10 * Time.deltaTime);
            //Di chuyen tren
        }
        else
        {
            if (posTarget.position == transform.position)
            {
                CheckBlock(0, -1);
            }
            if (isMove)
                transform.position = Vector3.MoveTowards(transform.position, posTarget.position, 10 * Time.deltaTime);
            //Di chuyen duoi
        }

    }
    private int currentPosx;
    private int currentPosz;
    private bool isMove = false;
    int numberChild;
    void CheckBlock(float x,float z)
    {
        currentPosx = (int)(transform.position.x + x);
        currentPosz = (int)(transform.position.z + z);
        string a = readText.a[currentPosx, currentPosz];
        if (a == null) return;
        //Debug.Log("aa");
        if (int.Parse(a) == 1 )
        {
            if (numberChild > 1)
            {
                Debug.Log("Nang len" + (numberChild - 1) * 0.11f);
                transform.position = new Vector3(transform.position.x, 1 + (numberChild - 1) * 0.11f, transform.position.z);
                posTarget.position = transform.position;
            }
            isMove = true;
            posTarget.position = new Vector3(currentPosx, transform.position.y, currentPosz);   
        }
        else if (int.Parse(a) == 2 && numberChild > 0)
        {
            readText.a[(int)(transform.position.x), (int)(transform.position.z)] = "5"; 
            RemoveBrick();
            isMove = true;
            posTarget.position = new Vector3(currentPosx, transform.position.y, currentPosz);
        }
        //else if (int.Parse(a) == 3)
        //{
        //    isMove = true;
        //    posTarget.position = new Vector3(currentPosx, transform.position.y, currentPosz);
        //}
        else isMove = false;
        //Debug.Log(a);
    }
   
    private void RemoveBrick()
    {
        Destroy(transform.GetChild(numberChild - 1).gameObject, 0.1f);
    }
    private void Win()
    {
        Debug.Log("Win");
    }
}
