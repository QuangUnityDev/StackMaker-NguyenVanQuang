using UnityEngine;
public class Brick : MonoBehaviour
{
    private GameObject player;
    private ReadText readText;
    int x, y;
    int numberChild;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        readText = GameObject.Find("ManagerRendMap").GetComponent<ReadText>();
         x = (int)(transform.position.x);
         y = (int)(transform.position.y);
    }
    private void Update()
    {
        numberChild = player.transform.childCount;
        Debug.Log(int.Parse(readText.a[x, y]));
        //Debug.Log(player.transform.position);

        if (player.transform.position.x == transform.position.x && player.transform.position.z == transform.position.z)
            {
                transform.SetParent(player.transform);
            for (int i = 0; i < numberChild; i++)
            {
                player.transform.GetChild(i).position = new Vector3(player.transform.position.x, player.transform.position.y - 1f - ((i * 0.11f)), player.transform.position.z);
            }          
            }
       
    }
   
}

