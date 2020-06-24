using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class GameContoller : MonoBehaviour,IPointerClickHandler
{
    public Text BudjetLabel;
    public Text UnrestLabel;
    public Text HealthyLabel;
    public Text SickLabel;
    public Text DeadLabel;
    public Text RecoverLabel;
    private Region regionScript;
    private bool reg;
    public void OnPointerClick(PointerEventData eventData){
        GameObject regionObject= eventData.rawPointerPress;
        regionScript = regionObject.GetComponent<Region>();
        reg=true;
        //a.transform.localScale=new Vector3(0.5f,0.5f,0.5f);
    }
    public float time = 1;
    // Start is called before the first frame update
    void Start()
    {
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
                Debug.Log(Mathf.FloorToInt(regionScript.I));*/
            }
        }
        
    }
}
