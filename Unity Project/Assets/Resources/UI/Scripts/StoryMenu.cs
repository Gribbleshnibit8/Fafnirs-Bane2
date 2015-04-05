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
		LoadStory("");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadStory(string storyFile)
	{
		var txt = (TextAsset)Resources.Load("Story/Story1", typeof(TextAsset));
		label.gameObject.SetActive(false);
		label.text = txt.text;
		label.gameObject.AddComponent<TypewriterEffect>();
		label.gameObject.GetComponent<TypewriterEffect>().charsPerSecond = 15;
		label.gameObject.SetActive(true);
	}





}

