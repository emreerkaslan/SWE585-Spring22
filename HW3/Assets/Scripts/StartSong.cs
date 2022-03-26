using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSong : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AudioPlayer.Instance.PlayMusic();
    }
}
