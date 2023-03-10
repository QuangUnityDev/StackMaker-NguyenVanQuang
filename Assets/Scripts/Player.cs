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
    [SerializeField] private GameObject block5;
    private void Start()
    {

        for (int i = 0; i < 5; i++)
        {
            int value = int.Parse(readText.a[0, i]);
            if (value == 3)
            {
                currentPosx = 0;
                currentPosz = i;
                transform.position = new Vector3(0f, transform.position.y, i);
                posTarget.position = transform.position;
            }
        }
    }
    void ClearWin()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
    private void Update()
    {
        if (GameManager.GetInstance().isGameStart != true) return;
        numberChild = transform.childCount;
        Debug.Log(numberChild);
        CheckWin();
        if (isWin) return;
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
                CheckBlock(1, 0);
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
    string a;
    void CheckBlock(float x, float z)
    {

        currentPosx = (int)(transform.position.x + x);
        currentPosz = (int)(transform.position.z + z);
        a = readText.a[currentPosx, currentPosz];

        if (a == null) return;
        //Debug.Log("aa");
        if (numberChild > 0)
        {
            Debug.Log("Nang len" + (numberChild - 1) * 0.11f);
            transform.position = new Vector3(transform.position.x, 1 + (numberChild - 1) * 0.11f, transform.position.z);
            posTarget.position = transform.position;
        }
        if (int.Parse(a) == 1)
        {

            isMove = true;
            posTarget.position = new Vector3(currentPosx, transform.position.y, currentPosz);
        }
        else if (int.Parse(a) == 2 && numberChild > 0)
        {
            if (readText.a[currentPosx, currentPosz] == "2")
            {
                RemoveBrick();
            }

            readText.a[currentPosx, currentPosz] = "1";
            isMove = true;
            posTarget.position = new Vector3(currentPosx, transform.position.y, currentPosz);
        }
        else if (int.Parse(a) == 4)
        {
            isMove = true;
            posTarget.position = new Vector3(currentPosx, transform.position.y, currentPosz);
            
        }
        else isMove = false;
        //Debug.Log(a);
    }
    void CheckWin( )
    {
        if(readText.a[(int)(transform.position.x), (int)(transform.position.z)] == "4")
        {
            isWin = true;
            transform.position = new Vector3(transform.position.x, 1 + (numberChild - 1) * 0.11f, transform.position.z);
            Win();
            Debug.Log("Win");
        }
    }
    bool isWin = false;
    private void RemoveBrick()
    {
        Destroy(transform.GetChild(numberChild - 1).gameObject, 0.1f);
    }
    private void Win()
    {
        if(numberChild > 0)
        {
            GameObject des = GameObject.FindObjectOfType<Brick>().gameObject;
            Destroy(des);
        }     
    }
}
