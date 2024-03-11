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
    
    public GameObject pauseMenuUI;

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
        if(Input.GetKeyUp(KeyCode.Space)){
            if(!pauseMenuUI.activeSelf){
                pauseMenuUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else{
                pauseMenuUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
        }
    }

    public void UpdateKill(){
        killtext.text = killTotal.ToString();
    }

    public void GameOver()
	{
        isGameOver = true;
        // ui_GameOverPage.SetActive(true);

    }

    public void RestartLevel()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    
}
