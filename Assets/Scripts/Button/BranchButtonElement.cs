using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BranchButtonElement : MonoBehaviour
{
    public BranchManager m_CommonButton;
    public int PopupIndex;

    // Start is called before the first frame update
    void Start()
    {
        m_CommonButton = GameObject.Find("BranchManager").GetComponent<BranchManager>();
        this.transform.GetChild(0).transform.GetComponent<Button>().onClick.AddListener(delegate { m_CommonButton.BackButtonEvent(PopupIndex); });        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
