using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPopUp : MonoBehaviour
{
    public VR_Manager VRModeMgr;
    public StagePlay m_StagePlay;


    // Start is called before the first frame update
    void Start()
    {
        m_StagePlay = FindObjectOfType<StagePlay>();
        VRModeMgr = FindObjectOfType<VR_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VRModeButtonEvent()
    {
        if (PlayerInfo.Instance.isComplite == true)
        {
            if (m_StagePlay.Narration.isPlaying == false)
            {
                VRModeMgr.VRModeStart();
                m_StagePlay.forwardDown();
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }
}
