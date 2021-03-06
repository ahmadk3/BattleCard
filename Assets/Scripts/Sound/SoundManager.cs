﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager Instance = null;

	public AudioClip winSound;
	public AudioClip shot;
	public AudioClip fireBall;
	public AudioClip arrow;
	public AudioClip thunder;

	private AudioSource soundEffectAudio;

	// Use this for initialization
	void Start () {

		// This is a singleton that makes sure you only
		// ever have one SoundManager
		// If someone tries to create another destroy it
		if (Instance == null)
		{
			Instance = this;
		} else if(Instance != this)
		{
			Destroy(gameObject);
		}

		// Use this instead
		AudioSource theSource = GetComponent<AudioSource> ();
		soundEffectAudio = theSource;
		DontDestroyOnLoad(gameObject);
	}

	// Any script can call this to play a sound effect
	public void PlayOneShot(AudioClip clip)
	{
		soundEffectAudio.PlayOneShot(clip, 0.4F);
	}
}