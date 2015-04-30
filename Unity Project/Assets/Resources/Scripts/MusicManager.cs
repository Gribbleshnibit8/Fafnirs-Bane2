using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{

	private AudioSource _audioSource;

	private ActiveMenu _previousMenu;

	// Use this for initialization
	void Start ()
	{
		_audioSource = GetComponent<AudioSource>();
		ChangeAudioSource();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (RootMenuManager.Instance.GetActiveMenu() != _previousMenu)
		{
			_previousMenu = RootMenuManager.Instance.GetActiveMenu();
			ChangeAudioSource();
		}
	}


	private void ChangeAudioSource()
	{
		_audioSource.Stop();

		var activeMenu = RootMenuManager.Instance.GetActiveMenu();
		AudioClip sound;

		switch (activeMenu)
		{
			case ActiveMenu.TitleMenu:
				sound = (AudioClip)Resources.Load("audio/Title screen", typeof(AudioClip));
				_audioSource.PlayOneShot(sound);
				break;

			case ActiveMenu.OverworldMenu:
				sound = (AudioClip)Resources.Load("audio/River walk", typeof(AudioClip));
				_audioSource.PlayOneShot(sound);
				break;

			case ActiveMenu.BattleMenu:
				sound = (AudioClip)Resources.Load("audio/Opening menu", typeof(AudioClip));
				_audioSource.PlayOneShot(sound);
				break;

		}

		_audioSource.loop = true;
	}



}
