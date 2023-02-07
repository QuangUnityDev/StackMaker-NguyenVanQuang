using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadText : MonoBehaviour
{
    public GameObject[] brick;
    public string[,] a;
    enum typeBrick
    {
        brick1,
        brick2,
        brick3,
        brick4,
        brick5
    }
    private void Awake()
    {
        LoadText();
    }
    private void LoadText()
    {
        string data = Resources.Load<TextAsset>("Maps/Map1").text;
        //Tach mang thanh 
        string[] save = data.Split(new string[] {"\n" }, System.StringSplitOptions.None);       
        a = new string[6, 5];
        for (int i = 0; i < 6; i++)
        {
            // save[0] {0,1,0,0}
            //Debug.Log(save[0]);
            string[] temp = save[i].Split(",");         
            for (int j = 0; j < 5; j++)
            {       
                // lay gia tri tung phan tu
                a[i,j] = temp[j];
                //Debug.Log(a[i, j]);
                RendMap(a[i, j],i,j);
            }
        }

    }
    void RendMap(string a,float x, float z)
    {
        int b = int.Parse(a);       
        switch (b)
        {
            case (int)(typeBrick.brick1):
                Instantiate(brick[0], new Vector3(x, 0, z), Quaternion.identity);
                //Debug.Log("gach khong di duoc");             
                break;
            case (int)(typeBrick.brick2):
                Instantiate(brick[1], new Vector3(x, 0, z), Quaternion.identity);
                //Debug.Log("gach di dc");
                break;
            case (int)(typeBrick.brick3):
                Instantiate(brick[2], new Vector3(x, 0, z), Quaternion.identity);
                //Debug.Log("gach di dc");
                break;
            case (int)(typeBrick.brick4):
                Instantiate(brick[3], new Vector3(x, 0, z), Quaternion.identity);
                //Debug.Log("gach di dc");
                break;
            case (int)(typeBrick.brick5):
                Instantiate(brick[4], new Vector3(x, 0, z), Quaternion.identity);
                //Debug.Log("gach di dc");
                break;

            default:
                break;
        }
    }
    //void SpwanBrick(int typeBrick,float x,float z)
    //{
    //    Instantiate(brick[typeBrick], new Vector3(x, 0, z), Quaternion.identity);
    //}
}
