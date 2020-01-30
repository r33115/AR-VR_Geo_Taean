using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VR_Manager : MonoBehaviour
{
    public Camera FirstPersonCamera;
    public StagePlay m_StagePlay;
    public GameObject checkPopUp;
    public GameObject TextObject;
    private GameObject[] aGarbage = new GameObject[7];

    private bool bStart = false;
    private bool bEnd = false;
    private int iCount = 0;
    public int Node;
    public int Group;
    public int ID;
    // Start is called before the first frame update
    void Start()
    {        
        for(int i = 0; i < aGarbage.Length; ++i)
        {
            aGarbage[i] = this.transform.GetChild(i).gameObject;
            aGarbage[i].SetActive(false);
            iCount++;
        }

        checkPopUp.SetActive(false);
        TextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (true == bEnd)
            return;

        if(true == bStart)
        {
            //pc 용....            
            if (Input.GetMouseButtonDown(0))
            {                
                RaycastHit hit;
                Ray ray = FirstPersonCamera.ScreenPointToRay(Input.mousePosition);

                //결국 아래 부분이 중요하다...
                bool bCheck = Physics.Raycast(ray, out hit, 30f);
                if (true == bCheck)
                {
                    GameObject gameObj = hit.collider.gameObject;
                    Destroy(gameObj);                    
                    iCount--;
                    TextObject.transform.GetComponent<Text>().text = "스마트폰을 움직여 쓰레기를 찾으세요.\n터치하여 쓰레기를 치울 수 있습니다.\n" + iCount + " / 7";
                    CheckEnd();
                }
            }
        }
    }

    // 끝났는지 확인하는 함수.. 카운트로 정해야 할 듯...
    void CheckEnd()
    {
        if(0 == iCount)
        {
            PlayerInfo.Instance.isComplite = true;            
            checkPopUp.SetActive(true);
            TextObject.SetActive(false);            
            bEnd = true;
        }
    }


    public void VRModeStart()
    {
        bStart = true;
        for (int i = 0; i < aGarbage.Length; ++i)
        {
            aGarbage[i].SetActive(true);
        }
        TextObject.SetActive(true);
    }

    //=============================================== BUTTON ===============================================//
    public void CheckButtonEvent()
    {
        checkPopUp.SetActive(false);
        TextObject.SetActive(false);

        int temp = -1;
        if (PlayerInfo.Instance.isComplite)
        {
            XML_Reader.Instance.scenarioToDict.BranchDictionary[m_StagePlay.sceneLoader.currentStage][Group][ID] = true;

            for (int k = 0; k < XML_Reader.Instance.scenarioToDict.BranchDictionary[m_StagePlay.sceneLoader.currentStage][Group].Count; k++)
            {
                if (XML_Reader.Instance.scenarioToDict.BranchDictionary[m_StagePlay.sceneLoader.currentStage][Group][k] == false)
                {
                    temp = m_StagePlay.Next;
                    break;
                }
                else
                {
                    temp = Node;
                }
            }

            m_StagePlay.Index = temp;
            m_StagePlay.Prev = XML_Reader.Instance.scenarioToDict.StageSetDictionary[m_StagePlay.sceneLoader.currentStage].PageList[m_StagePlay.Index].Prev;
            m_StagePlay.Next = XML_Reader.Instance.scenarioToDict.StageSetDictionary[m_StagePlay.sceneLoader.currentStage].PageList[m_StagePlay.Index].Next;
            PlayerInfo.Instance.isComplite = false;
            m_StagePlay.StageSet();
        }
    }
    


}
