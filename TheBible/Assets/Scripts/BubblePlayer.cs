using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class BubblePlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage rawImage;
    private bool onceTime;
    void Start()
    {
        StartCoroutine(PlayVideo());
        onceTime = true;
    }
    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onceTime && collision.gameObject.CompareTag("Player"))
        {
            // 말풍선 플레이
            Debug.Log("video play");
            videoPlayer.Play();
            onceTime = false;
        }
    }
}
