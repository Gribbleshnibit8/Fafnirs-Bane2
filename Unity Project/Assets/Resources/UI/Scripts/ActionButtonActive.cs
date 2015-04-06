using System;
using UnityEngine;
using System.Collections;

public class ActionButtonActive : MonoBehaviour
{

	private UILabel _labelName;
	private UILabel _labelLeft;
	private UILabel _labelRight;
	private UISprite _sprite;



	void Awake()
	{
		_labelName = GetComponentsInChildren<UILabel>()[0];
		_labelLeft = GetComponentsInChildren<UILabel>()[1];
		_labelRight = GetComponentsInChildren<UILabel>()[2];

		_sprite = GetComponentInChildren<UISprite>();

		Sprite = "";
		LabelName = "";
		LabelLeft = "";
		LabelRight = "";
	}


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	#region Accessors

	public string LabelName
	{
		get { return _labelName.text; }
		set
		{
			if (String.IsNullOrEmpty(value))
			{
				_labelName.text = "";
				_labelName.enabled = false;
			}
			else
			{
				_labelName.text = value;
				_labelName.enabled = true;
			}
		}
	}
	public Color LabelNameColor
	{
		get { return _labelName.color; }
		set { _labelName.color = value; }
	}

	public string LabelLeft
	{
		get { return _labelLeft.text; }
		set
		{
			if (String.IsNullOrEmpty(value))
			{
				_labelLeft.text = "";
				_labelLeft.enabled = false;
			}
			else
			{
				_labelLeft.text = value;
				_labelLeft.enabled = true;
			}
		}
	}
	public Color LabelLeftColor
	{
		get { return _labelLeft.color; }
		set { _labelLeft.color = value; }
	}

	public string LabelRight
	{
		get { return _labelRight.text; }
		set
		{
			if (String.IsNullOrEmpty(value))
			{
				_labelRight.text = "";
				_labelRight.enabled = false;
			}
			else
			{
				_labelRight.text = value;
				_labelRight.enabled = true;
			}
		}
	}
	public Color LabelRightColor
	{
		get { return _labelRight.color; }
		set { _labelRight.color = value; }
	}

	public string Sprite
	{
		get { return _sprite.spriteName; }
		set
		{
			if (String.IsNullOrEmpty(value))
			{
				_sprite.spriteName = "";
				_sprite.enabled = false;
			}
			else
			{
				_sprite.spriteName = value;
				_sprite.enabled = true;
			}
		}
	}


	#endregion Accessors
}

