using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class GameContoller : MonoBehaviour,IPointerClickHandler
{
    //UI
    public Text BudjetLabel;
    public Text UnrestLabel;
    public Text HealthyLabel;
    public Text SickLabel;
    public Text DeadLabel;
    public Text RecoverLabel;

    //All
    private int All;
    private int AllHealth;
    private int AllDead;
    private int AllRecover;
    private int AllSick;

    //Region
    private Region regionScript;
    public List<GameObject> Regions;
    private List<Region> RegionScripts = new List<Region>();
    private bool reg;
    public void OnPointerClick(PointerEventData eventData){
      
        GameObject clickObject= eventData.rawPointerPress;
        if(clickObject.tag=="All"){
        Debug.Log("Click All");
        for (int i=0; i<Regions.Count;i++){
            Regions[i].tag="Region";
        }
        reg=false;
        }
        else if(clickObject.tag=="Region"){
        Debug.Log("Click Region");
        regionScript = clickObject.GetComponent<Region>();
        for (int i=0; i<Regions.Count;i++){
            
            if(Regions[i]==clickObject){
                continue;
            }
            else{
                Regions[i].tag="All";
            }
        }
        reg=true;
        }
        
        
        //a.transform.localScale=new Vector3(0.5f,0.5f,0.5f);
    }
    public float time = 1;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<Regions.Count;i++){
            
            RegionScripts.Add(Regions[i].GetComponent<Region>());
        
        }
        
        reg=false;
    }
    public void AllSelect(){
        for (int i=0; i<Regions.Count;i++){
            Regions[i].tag="Region";
        }
        reg=false;
    }
    
    // Update is called once per frame
    void Update()
    {   

        


        if(reg){
            HealthyLabel.text=Mathf.FloorToInt(regionScript.S).ToString();
            DeadLabel.text=Mathf.FloorToInt(regionScript.D).ToString();
            RecoverLabel.text=Mathf.FloorToInt(regionScript.R).ToString();
            SickLabel.text=Mathf.FloorToInt(regionScript.I).ToString();
            /*if(Mathf.FloorToInt(regionScript.S)+Mathf.FloorToInt(regionScript.D)+Mathf.FloorToInt(regionScript.R)+Mathf.FloorToInt(regionScript.I)!=10000000){
                Debug.Log(Mathf.FloorToInt(regionScript.S)+Mathf.FloorToInt(regionScript.D)+Mathf.FloorToInt(regionScript.R)+Mathf.FloorToInt(regionScript.I));
                Debug.Log(Mathf.FloorToInt(regionScript.S));
                Debug.Log(Mathf.FloorToInt(regionScript.D));
                Debug.Log(Mathf.FloorToInt(regionScript.R));
                Debug.Log(Mathf.FloorToInt(regionScript.I));
            }*/
        }
        if(!reg){
            All=0;
            AllHealth=0;
            AllDead=0;
            AllRecover=0;
            AllSick=0;
            for (int i=0; i<RegionScripts.Count;i++)
            {
            All=All+Mathf.FloorToInt(RegionScripts[i].N);
            AllHealth=AllHealth+Mathf.FloorToInt(RegionScripts[i].S);
            AllDead=AllDead+Mathf.FloorToInt(RegionScripts[i].D);
            AllRecover=AllRecover+Mathf.FloorToInt(RegionScripts[i].R);
            AllSick=AllSick+Mathf.FloorToInt(RegionScripts[i].I);
            
            }
            HealthyLabel.text=AllHealth.ToString();
            DeadLabel.text=AllDead.ToString();
            RecoverLabel.text=AllRecover.ToString();
            SickLabel.text=AllSick.ToString();
           
        }
        
    }
}
