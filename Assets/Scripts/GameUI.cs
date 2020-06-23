using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    //Game variable display
    public Text BudjetLabel;
    public Text UnrestLabel;
    public Text HealthyLabel;
    public Text SickLabel;
    public Text DeadLabel;

    //Menu
    public GameObject SettingsMenu;

    //Time
    public GameObject GameControl;
    private GameContoller GameScript;
    public bool paused = false;

    //UI
    public GameObject GameMenu;
    public GameObject MenuAction;
    

    // Start is called before the first frame update
    void Start()
    {
        GameScript = GameControl.GetComponent<GameContoller>();
    }

    //Game variable display



    //Menu
    public void CloseMenu()
    {
        GameMenu.SetActive(false);
    }

    public void MainMenu()
    {
        StartCoroutine(LoadAsync("MainMenu"));
    }

    public void Settings()
    {
        SettingsMenu.SetActive(true);
    }

    public void ExitSettings(){
        SettingsMenu.SetActive(false);
    }

    IEnumerator LoadAsync(string SceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    //Time
    public void TimeX1()
    {
        Time.timeScale = 1;
        paused=false;
        GameScript.time=1f;
    }
    public void TimeX2()
    {
        Time.timeScale = 1;
        paused=false;
        GameScript.time=2f;
    }
    public void TimeX3()
    {
        Time.timeScale = 1;
        paused=false;
        GameScript.time=3f;
    }
    public void TimePause()
    {
        if(!paused){
        Time.timeScale = 0;
        paused=true;
        }
        else{
        Time.timeScale = 1;
        paused=false;
        }
    }

    //UI
    public void OpenMenu()
    {
        GameMenu.SetActive(true);
    }

    public void CloseActionMenu()
    {
        MenuAction.SetActive(false);
    }


    public void OpenActionMenu()
    {
        MenuAction.SetActive(true);
    }

    




    

   
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
