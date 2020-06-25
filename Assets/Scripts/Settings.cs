using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    //Difficult
    public float N;
    public float I;
    public float C;
    public float g;
    public float a;



    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
       DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
