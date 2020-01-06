using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordCollection : MonoBehaviour
{
    private GameObject[] aBadges = new GameObject[3];
    private int iCount = -1;
    private bool bStart = false;
    private string strEdu_type = "geo";

    private int iStage = 0;
    private int iCollectionCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < aBadges.Length; ++i)
        {
            aBadges[i] = this.transform.GetChild(i + 1).gameObject;
            aBadges[i].SetActive(false);
        }

        CheckBadgeCollection();
    }

    // Update is called once per frame
    void Update()    {    }




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
        DatabaseManager.Instance.ShowBadgeCollection(appID, userID, kind, edu_type);
    }
    public void ContinueShowBadgeCollection(string _resultText)
    {
        if ("" == _resultText)
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



    //================================================= BUTTON ===========================================//
    public void BackButtonEvent()
    {
        Debug.Log("back");
        SceneManager.LoadScene("SelectMap");
    }
}
