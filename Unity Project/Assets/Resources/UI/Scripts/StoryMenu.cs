using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class StoryMenu : MonoBehaviour
{

	private UILabel label;

	void Awake()
	{
		label = GetComponentInChildren<UILabel>();
	}
	// Use this for initialization
	void Start () {
		LoadStory("opening");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		//if (!label.gameObject.GetComponent<TypewriterEffect>())

	}

	public void LoadStory(string storyFile)
	{
		storyFile = "Story/" + storyFile;
		var text = (Resources.Load(storyFile, typeof(TextAsset))).ToString();

		var lines = text.Split('#').ToList();

		for (int index = 0; index < lines.Count; index++)
		{
			lines[index] = lines[index].Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
		}

		StartCoroutine( PlayStory(lines) );
	}

	IEnumerator PlayStory(List<string> lines)
	{

		int index = 0;

		while (true)
		{
			while (label.gameObject.GetComponent<TypewriterEffect>())
				yield return new WaitForSeconds(1.5f);
			
			label.text = lines[index];
			label.gameObject.AddComponent<TypewriterEffect>();
			label.gameObject.GetComponent<TypewriterEffect>().charsPerSecond = 15;
			label.gameObject.SetActive(true);

			index++;

			if (index >= lines.Count)
				yield break;

		}

	}





}

