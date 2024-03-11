using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //singleton
    //it's static so it can be accessed by other scripts
    public static GameManager instance;

    public GameObject player;
    public int killTotal = 0;
    public TMP_Text killtext;

    [HideInInspector]
    public bool isGameOver = false;
    [SerializeField]
    public GameObject ui_GameOverPage;

    void Awake()
    {
        if(instance == null)
		{
            instance = this;
		}
        else
		{
            Destroy(gameObject);
		}
    }

    // Update is called once per frame
    void Update()
    {
        UpdateKill();
    }

    public void UpdateKill(){
        killtext.text = killTotal.ToString();
    }

    public void GameOver()
	{
        isGameOver = true;
        ui_GameOverPage.SetActive(true);

    }

    public void RestartLevel()
	{
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    
}
