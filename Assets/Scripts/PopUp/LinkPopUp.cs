using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkPopUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LinkButtonEvent()
    {
        Application.OpenURL("http://www.taean.go.kr/slowcity/index.do");
    }


}
