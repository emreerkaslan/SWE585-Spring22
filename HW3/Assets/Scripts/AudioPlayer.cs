using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
	private AudioSource _source;
	public AudioClip music;

	private bool isPlaying;

	public static AudioPlayer Instance;

	private void Awake()
	{
		DontDestroyOnLoad(this);
		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}

	}

	void Start()
	{
		_source = GetComponent<AudioSource>();
		_source.clip = music;
		isPlaying = false;
	}


	public void PlayMusic()
	{
		if (isPlaying) return;
		_source.Play();
		isPlaying = true;
	}


	public void StopMusic()
	{
		_source.Stop();
		isPlaying = false;
	}

}
