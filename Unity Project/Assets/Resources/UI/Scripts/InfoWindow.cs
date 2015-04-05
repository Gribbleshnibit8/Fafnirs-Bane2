using UnityEngine;
using System.Collections;

public class InfoWindow : MonoBehaviour
{

	private UILabel _label;

	public string Label
	{
		get { return _label.text; }
		set { _label.text = value; }
	}

	private UISprite _background;

	public bool Background
	{
		get { return _background.enabled; }
		set { _background.enabled = value; }
	}

	void Awake()
	{
		_label = GetComponentInChildren<UILabel>();
		_background = GetComponentInChildren<UISprite>();
	}
}
