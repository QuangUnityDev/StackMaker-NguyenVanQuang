using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadText : MonoBehaviour
{
    [SerializeField] private GameObject[] brick;
    enum typeBrick
    {
        brick1 = 0,
        brick2 = 1,
        brick3 = 2
    }
    private void Start()
    {
        LoadText();
        int b = (int)(typeBrick.brick1);
     
        Debug.Log(b);
        
    }
    private void LoadText()
    {
        string data = Resources.Load<TextAsset>("Maps/Map1").text;
        string[] save = data.Split(new string[] {"\n" }, System.StringSplitOptions.None);       
        string[,] a = new string[3, 4];
        for (int i = 0; i < 3; i++)
        {
            string[] temp = save[i].Split(",");
            for (int j = 0; j < 4; j++)
            {              
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
                Debug.Log("gach khong di duoc");             
                break;
            case (int)(typeBrick.brick2):
                Instantiate(brick[1], new Vector3(x, 0, z), Quaternion.identity);
                Debug.Log("gach di dc");
                break;
            case (int)(typeBrick.brick3):
                Instantiate(brick[2], new Vector3(x, 0, z), Quaternion.identity);
                Debug.Log("gach di dc");
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
