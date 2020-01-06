using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BranchManager : MonoBehaviour
{
    public GameObject mainCanvas;

    public GameObject questionPopup1;
    public GameObject questionPopup2;
    public GameObject questionPopup3;
    public GameObject questionPopup4;
    public GameObject questionPopup5;
    public GameObject questionPopup6;
    public GameObject questionPopup7;

    public GameObject backPopup1;
    public GameObject backPopup2;
    public GameObject backPopup3;
    public GameObject backPopup4;
    public GameObject backPopup5;
    public GameObject backPopup6;
    public GameObject backPopup7;

    public GameObject TextBox;
    public GameObject BranchForward;

    // hmm.... 테스트 해봐야 함....
    private string text1_1 = "흠... 귀찮은데.";
    private string text1_2 = "내 배지를 받기 싫은가 보네.";

    private string text2_1 = "오.. 대단한걸? 생태관광에 대해 정확히 이해했구나!";
    private string text2_2 = "생태관광의 조건을 다시 생각해 봐.";

    private string text3_1 = "듣지 않고 그냥 간다.";
    private string text3_2 = "나의 배지를 받지 않을 셈이야?";

    private string text4_1 = "아직 준비가 안됐어요.";
    private string text4_2 = "배지를 얻으려면 준비를 마친 뒤, 다시 와 주세요.";

    private string text5_1 = "신두리 해안사구를 충분히 눈으로 보았는데, 형성과정까지 알아야 하나요?";
    private string text5_2 = "###님, 무엇이든지 아는 만큼 더 잘 보이는 법이랍니다.";

    private string text6_1 = "두웅습지에 대해 이미 충분히 알고 있어요.";
    private string text6_2 = "글쎄, 자네는 두웅습지에 대해 충분히 알고 있다고 하지만, 1만년 전의 이곳은 전혀 다른 모습이었지. 이 부분에 대해 좀 더 자세히 알려주도록 하겠네.";

    private string text7_1 = "두웅습지에 금개구리님이 살고 있어서지요.";
    private string text7_2 = "껄껄껄! 그것도 맞는 말이지만, 좀더 자세히 알려주도록 하겠네..";

    private int iPopupIndex = -1;


    // Start is called before the first frame update
    void Start()
    {
        questionPopup1 = mainCanvas.transform.GetChild(0).transform.Find("Question_PopUp_1").gameObject;        // 성공...
        questionPopup2 = mainCanvas.transform.GetChild(0).transform.Find("Question_PopUp_2").gameObject;
        questionPopup3 = mainCanvas.transform.GetChild(0).transform.Find("Question_PopUp_3").gameObject;
        questionPopup4 = mainCanvas.transform.GetChild(0).transform.Find("Question_PopUp_4").gameObject;
        questionPopup5 = mainCanvas.transform.GetChild(0).transform.Find("Question_PopUp_5").gameObject;
        questionPopup6 = mainCanvas.transform.GetChild(0).transform.Find("Question_PopUp_6").gameObject;
        questionPopup7 = mainCanvas.transform.GetChild(0).transform.Find("Question_PopUp_7").gameObject;

        backPopup1 = mainCanvas.transform.GetChild(0).transform.Find("Back_PopUp_1").gameObject;
        backPopup2 = mainCanvas.transform.GetChild(0).transform.Find("Back_PopUp_2").gameObject;
        backPopup3 = mainCanvas.transform.GetChild(0).transform.Find("Back_PopUp_3").gameObject;
        backPopup4 = mainCanvas.transform.GetChild(0).transform.Find("Back_PopUp_4").gameObject;
        backPopup5 = mainCanvas.transform.GetChild(0).transform.Find("Back_PopUp_5").gameObject;
        backPopup6 = mainCanvas.transform.GetChild(0).transform.Find("Back_PopUp_6").gameObject;
        backPopup7 = mainCanvas.transform.GetChild(0).transform.Find("Back_PopUp_7").gameObject;

        TextBox = mainCanvas.transform.GetChild(0).transform.Find("TextBox").gameObject;
        BranchForward = mainCanvas.transform.GetChild(0).transform.Find("forward_branch").gameObject;


        // 일다 여기서 초기화....
        BranchForward.transform.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, 0f, 0f);
        BranchForward.transform.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        BranchForward.transform.GetComponent<RectTransform>().offsetMin = new Vector2(4.5f, 8.5f);
        BranchForward.transform.GetComponent<RectTransform>().offsetMax = new Vector2(3.5f, 6.5f);
        BranchForward.GetComponent<Button>().onClick.AddListener(delegate { this.NextButtonEvent();  });

        // back popup...
        // popup 1
        backPopup1.transform.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, 0f, 0f);
        backPopup1.transform.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        backPopup1.transform.GetComponent<RectTransform>().offsetMin = new Vector2(700f, 650f);
        backPopup1.transform.GetComponent<RectTransform>().offsetMax = new Vector2(-700f, -250f);
        
        // popup 2
        backPopup2.transform.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, 0f, 0f);
        backPopup2.transform.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        backPopup2.transform.GetComponent<RectTransform>().offsetMin = new Vector2(700f, 650f);
        backPopup2.transform.GetComponent<RectTransform>().offsetMax = new Vector2(-700f, -250f);

        // popup 3
        backPopup3.transform.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, 0f, 0f);
        backPopup3.transform.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        backPopup3.transform.GetComponent<RectTransform>().offsetMin = new Vector2(700f, 650f);
        backPopup3.transform.GetComponent<RectTransform>().offsetMax = new Vector2(-700f, -250f);

        // popup 3
        backPopup4.transform.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, 0f, 0f);
        backPopup4.transform.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        backPopup4.transform.GetComponent<RectTransform>().offsetMin = new Vector2(700f, 650f);
        backPopup4.transform.GetComponent<RectTransform>().offsetMax = new Vector2(-700f, -250f);

        // popup 6
        backPopup6.transform.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, 0f, 0f);
        backPopup6.transform.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        backPopup6.transform.GetComponent<RectTransform>().offsetMin = new Vector2(700f, 650f);
        backPopup6.transform.GetComponent<RectTransform>().offsetMax = new Vector2(-700f, -250f);

        // popup 7
        backPopup7.transform.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, 0f, 0f);
        backPopup7.transform.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        backPopup7.transform.GetComponent<RectTransform>().offsetMin = new Vector2(700f, 650f);
        backPopup7.transform.GetComponent<RectTransform>().offsetMax = new Vector2(-700f, -250f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }





    // 여기에다가 한다.....
    // 따로 대사를 가져와야 한다.. 그게 문제인데....
    // 일단 여기에 다가 한다. 두 번째 대사인셈..
    // 삭제 예정....
    public void Test()
    {
        string Contents = "hahahaha";
        Text text = TextBox.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
        GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(Contents, text);
    }

    // index 에 따라서....
    public void PrintText(int _iPopupIndex)
    {
        if (false == PlayerInfo.Instance.isComplite)
            return;

        iPopupIndex = _iPopupIndex;
        string Contents = "";

        if (1 == iPopupIndex)
        {
            Contents = text1_1;
        }
        else if (2 == iPopupIndex)
        {
            QuestionPopupActive(iPopupIndex, false);
            NextButtonEvent();
            return;
        }
        else if (3 == iPopupIndex)
        {
            Contents = text3_1;
        }
        else if (4 == iPopupIndex)
        {
            Contents = text4_1;
        }
        else if (6 == iPopupIndex)
        {
            Contents = text6_1;
        }
        else if (7 == iPopupIndex)
        {
            Contents = text7_1;
        }

        if (false == TextBox.activeSelf)        
            TextBox.SetActive(true);
        
        Text text = TextBox.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
        GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(Contents, text);

        BranchForward.SetActive(true);
        QuestionPopupActive(iPopupIndex, false);       
    }

    void NextButtonEvent()
    {
        string Contents = "";

        if (1 == iPopupIndex)
        {
            Contents = text1_2;
        }
        else if (2 == iPopupIndex)
        {
            Contents = text2_2;
        }
        else if (3 == iPopupIndex)
        {
            Contents = text3_2;
        }
        else if (4 == iPopupIndex)
        {
            Contents = text4_2;
        }
        else if (6 == iPopupIndex)
        {
            Contents = text6_2;
        }
        else if (7 == iPopupIndex)
        {
            Contents = text7_2;
        }

        Text text = TextBox.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
        GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(Contents, text);

        BackPopupActive(iPopupIndex, true);

        BranchForward.SetActive(false);
    }






    void QuestionPopupActive(int _iIndex, bool _bValue)
    {
        int iIndex = _iIndex;
        bool bValue = _bValue;

        if (1 == iPopupIndex)
        {
            questionPopup1.SetActive(bValue);
        }
        else if (2 == iPopupIndex)
        {
            questionPopup2.SetActive(bValue);
        }
        else if (3 == iPopupIndex)
        {
            questionPopup3.SetActive(bValue);
        }
        else if (4 == iPopupIndex)
        {
            questionPopup4.SetActive(bValue);
        }
        else if (5 == iPopupIndex)
        {
            questionPopup5.SetActive(bValue);
        }
        else if (6 == iPopupIndex)
        {
            questionPopup6.SetActive(bValue);
        }
        else if (7 == iPopupIndex)
        {
            questionPopup7.SetActive(bValue);
        }
    }
    
    void BackPopupActive(int _iIndex, bool _bValue)
    {
        int iIndex = _iIndex;
        bool bValue = _bValue;

        if (1 == iIndex)
        {            
            backPopup1.SetActive(bValue);
        }
        else if (2 == iIndex)
        {            
            backPopup2.SetActive(bValue);
        }
        else if (3 == iIndex)
        {         
            backPopup3.SetActive(bValue);
        }
        else if (4 == iIndex)
        {         
            backPopup4.SetActive(bValue);
        }
        else if (5 == iIndex)
        {            
            backPopup5.SetActive(bValue);
        }
        else if (6 == iIndex)
        {
            backPopup6.SetActive(bValue);
        }
        else if (7 == iIndex)
        {
            backPopup6.SetActive(bValue);
        }
    }


    public void TestHaha()
    {
        Debug.Log("haha");
    }

    public void BackButtonEvent(int _iIndex)
    {
        if (false == PlayerInfo.Instance.isComplite)
            return;


        int iIndex = _iIndex;
        if (1 == iIndex)
        {
            questionPopup1.SetActive(true);
            backPopup1.SetActive(false);            
        }
        else if(2 == iIndex)
        {
            questionPopup2.SetActive(true);
            backPopup2.SetActive(false);
        }
        else if (3 == iIndex)
        {
            questionPopup3.SetActive(true);
            backPopup3.SetActive(false);
        }
        else if (4 == iIndex)
        {
            questionPopup4.SetActive(true);
            backPopup4.SetActive(false);
        }
        else if (5 == iIndex)
        {
            questionPopup5.SetActive(true);
            backPopup5.SetActive(false);
        }
        else if (6 == iIndex)
        {
            questionPopup6.SetActive(true);
            backPopup6.SetActive(false);
        }
        else if (7 == iIndex)
        {
            questionPopup7.SetActive(true);
            backPopup7.SetActive(false);
        }
    }
}
