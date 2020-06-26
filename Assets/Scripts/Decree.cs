using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Decree : MonoBehaviour
{

    public GameObject Game;
    public GameContoller GameScript;
    //public GameObject UI;
    //public GameUI UIScript;
    public float budget;
    public float unrest;
    public float C;
    public float beta;
    public bool SwitchOn;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        GameScript=Game.GetComponent<GameContoller>();
        //UIScript=UI.GetComponent<GameUI>();
    }
    public void SwitchChange(){
        if(SwitchOn){
            SwitchOn=false;
            //GameScript.Selected.GetComponent<Region>().decree[id]=false;
            ToggleF();
        }
        else{
            SwitchOn=true;
            //GameScript.Selected.GetComponent<Region>().decree[id]=true;
            ToggleF();
        }
    }
    public void ToggleF(){
        if (SwitchOn){
            
                if(GameScript.Budget>=-budget){
                    GameScript.Budget=GameScript.Budget+budget;
                    GameScript.Unrest=GameScript.Unrest+unrest;
                    GameScript.ChangeRegionModel(C,beta,GameScript.Selected,id,true);
                }
                else{
                    SwitchOn=false;
                    this.GetComponent<Toggle>().isOn=false;
                }
            
            
        }
        else if (!SwitchOn){
            
            
                GameScript.Unrest=GameScript.Unrest-unrest;
                GameScript.ChangeRegionModel(-C,-beta,GameScript.Selected,id,false);
                }
            
            
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }
}
