using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]private Button bt_ClickTapTap;
    public GameObject panelStartGame;
    
    void Start()
    {
        panelStartGame.gameObject.SetActive(true);
        bt_ClickTapTap.onClick.AddListener(GameStart);
    }
 void GameStart()
    {
        GameManager.GetInstance().countClickStart++;
        if (GameManager.GetInstance().countClickStart == 2)
        {
            panelStartGame.gameObject.SetActive(false);
            GameManager.GetInstance().isGameStart = true;
        }       
    }
}
