using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionPopup : MonoBehaviour
{
    public StagePlay m_StagePlay;    

    private GameObject[] aBadges = new GameObject[3];
    private int iCount = -1;
    private bool bStart = false;
    private string strEdu_type = "geo";

    private int iStage = 0;
    private int iCollectionCount = 1;

    private void Awake()
    {
        for (int i = 0; i < aBadges.Length; ++i)
        {
            aBadges[i] = this.transform.GetChild(i + 1).gameObject;
            aBadges[i].SetActive(false);
        }

        m_StagePlay = FindObjectOfType<StagePlay>();        
        bStart = true;        
        iStage = m_StagePlay.sceneLoader.currentStage;
        Debug.Log("Pop Up");        
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        iCount++;
        if (0 == iCount)
            return;


        iCollectionCount = 1;
        iStage = m_StagePlay.sceneLoader.currentStage;
        ObtainBadgeCollection();

        //int iStage = m_StagePlay.sceneLoader.currentStage;
        //aBadges[iStage-1].SetActive(true);
        // 일단 보여주기....                           
        //CheckBadgeCollection();        
    }

    // Update is called once per frame
    void Update()    {  }



    void CheckBadgeCollection()
    {
        string appID = PlayerInfo.Instance.GetAppID();        
        string userID = PlayerInfo.Instance.GetUserID();
        //string kind = "social_sticker_first";
        string kind = "";
        string get_flag = "";
        string edu_type = strEdu_type + "_experience";
        string game_type = "VR";
        int timeInfo = 0;

        if (1 == iCollectionCount)
        {
            kind = strEdu_type + "_badge_first";
        }
        else if (2 == iCollectionCount)
        {
            kind = strEdu_type + "_badge_second";
        }
        else if (3 == iCollectionCount)
        {
            kind = strEdu_type + "_badge_third";
        }
        else
        {            
            return;
        }

        // 그리고 보낸다...
        DatabaseManager.Instance.GetBadgeCollection(appID, userID, kind, edu_type);
    }

    public void ContinueGetBadgeCollection(string _resultText)
    {
        if("" == _resultText)
        {
            // 없음..
            aBadges[iCollectionCount - 1].SetActive(false);
        }
        else
        {
            // 있음...
            aBadges[iCollectionCount - 1].SetActive(true);
        }
        ++iCollectionCount;
        CheckBadgeCollection();
    }

    public void ObtainBadgeCollection()
    {
        string appID = PlayerInfo.Instance.GetAppID();
        string userID = PlayerInfo.Instance.GetUserID();
        //string kind = "social_sticker_first";
        string kind = "";
        string get_flag = "";
        string edu_type = strEdu_type + "_experience";
        string game_type = "VR";

        if (1 == iStage)
            kind = strEdu_type + "_badge_first";
        else if (2 == iStage)
            kind = strEdu_type + "_badge_second";
        else if (3 == iStage)
            kind = strEdu_type + "_badge_third";

        DatabaseManager.Instance.UpdateBadgeCollection(appID, userID, kind, edu_type);        
    }
}
