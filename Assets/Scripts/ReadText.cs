using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadText : MonoBehaviour
{
    private void Start()
    {
        LoadText();
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
                Debug.Log(a[i, j]);
                RendMap(a[i, j]);
            }
        }

    }
    void RendMap(string a)
    {
        int b = int.Parse(a);

        switch (b)
        {
            case 0:
                Debug.Log("gach khong di duoc");
                break;
            case 1:
                Debug.Log("gach di dc");
                break;
            default:
                break;
        }
    }
}
