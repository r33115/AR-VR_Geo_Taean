using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButtonElement : MonoBehaviour
{
    public StagePlay m_StagePlay;
    public int next;

    // Start is called before the first frame update
    void Start()
    {
        m_StagePlay = FindObjectOfType<StagePlay>();
        //this.GetComponent<Button>().onClick.AddListener(delegate { m_StagePlay.forwardDown(); });
        this.GetComponent<Button>().onClick.AddListener(delegate { this.ButtonEvent(); });
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonEvent()
    {
        m_StagePlay.Next = next;
        m_StagePlay.forwardDown();
    }


}
