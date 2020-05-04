// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Video;

// public class BubblePlayer : MonoBehaviour
// {
//     public VideoPlayer videoPlayer;
//     public RawImage rawImage;
//     private bool onceTime;
//     WaitForSeconds waitForSeconds = new WaitForSeconds(1);

//     void Start()
//     {
//         StartCoroutine(PlayVideo());
//         onceTime = true;
//     }

//     IEnumerator PlayVideo()
//     {
//         videoPlayer.Prepare();

//         while (!videoPlayer.isPrepared)
//         {
//             yield return waitForSeconds;
//             Debug.Log("video play is not PrePared");
//             break;
//         }

//         rawImage.texture = videoPlayer.texture;
//         Debug.Log("rawImage Texture setting!");
//         StopCoroutine(PlayVideo());
//         yield return new WaitForEndOfFrame();
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (onceTime && collision.gameObject.CompareTag("Player"))
//         {
//             rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, 1f);
//             // 말풍선 플레이
//             Debug.Log("video play");
//             videoPlayer.Play();
//             onceTime = false;
//         }
//     }
// }
