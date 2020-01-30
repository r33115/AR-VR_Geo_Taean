using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPopup : MonoBehaviour
{
    public StagePlay m_StagePlay;

    public VideoPlayer videoSc;
    public GameObject playButton;
    public GameObject nextButton;

    private GameObject videoPlayerObject;

    // 버튼 추가 예정...
    // 다음 버튼...
    // 버튼이 아니라 그냥 끄기....

    // Start is called before the first frame update
    void Start()
    {
        m_StagePlay = FindObjectOfType<StagePlay>();
        videoSc.targetCamera = GameObject.Find("Main Camera").transform.GetComponent<Camera>();        
        videoPlayerObject = this.transform.GetChild(0).gameObject;
    }


    IEnumerator PlayVideo()
    {        
        yield return new WaitForEndOfFrame();
        videoSc.Play();
        // 일단 기다린다.... 플레이 시작할 때 까지..
        yield return new WaitUntil(() => videoSc.isPlaying);
        // play 시작되고,,
        //Debug.Log("play video");
        yield return new WaitUntil(() => !videoSc.isPlaying);
        //Debug.Log("end video");
        // 여기서 버튼 활성화...
        playButton.SetActive(true);
        nextButton.SetActive(true);

        videoPlayerObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()    {    }




    //======================================== BUTTON EVENT ================================================//
    public void VideoPlayButtonEvent()
    {
        playButton.SetActive(false);
        nextButton.SetActive(false);

        videoPlayerObject.SetActive(true);        
        StartCoroutine(PlayVideo());
    }
    public void NextButtonEvent()
    {
        m_StagePlay.forwardDown();
    }

}
