using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	//array of sound effects & music
	public Sound music;
	private static AudioManager instance;

	// Ensure that only one Audio Manager exists
	void Awake()
	{
		if (instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);

		// Initialize the Sound clips
		music.source = gameObject.AddComponent<AudioSource>();
		music.source.clip = music.clip;

		music.source.volume = music.volume;
		music.source.pitch = music.pitch;
		music.source.loop = music.loop;
	}

    // Play a Sound by name, ex. Play("Song1")
    public void Play(string name)
	{
		music.source.Play();
	}

	// Stop a Sound by name, ex. Stop("Song1")
	public void Stop(string name)
	{
		music.source.Stop();
	}

}
