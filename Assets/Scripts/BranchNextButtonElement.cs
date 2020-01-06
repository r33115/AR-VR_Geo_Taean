using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BranchNextButtonElement : MonoBehaviour
{
    public BranchManager m_CommonButton;
    public int iPopupIndex;

    // Start is called before the first frame update
    void Start()
    {
        m_CommonButton = FindObjectOfType<BranchManager>();
        this.GetComponent<Button>().onClick.AddListener(delegate { m_CommonButton.PrintText(iPopupIndex); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
