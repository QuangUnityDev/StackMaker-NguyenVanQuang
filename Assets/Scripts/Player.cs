using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Stack<Brick> owner;
    Vector2 starPos;
    Vector2 endPos;
    bool isTouch;
    private void Update()
    {
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
        Debug.Log(ange);

    }
    private void AddBrick()
    {

    }
    private void RemoveBrick()
    {

    }
    private void Move()
    {
        
    }
    private void Win()
    {

    }
}
