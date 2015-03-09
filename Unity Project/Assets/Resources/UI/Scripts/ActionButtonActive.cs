using System;
using UnityEngine;
using System.Collections;

public class ActionButtonActive : MonoBehaviour
{

	private UILabel _labelName;
	private UILabel _labelCost;
	private UILabel _labelGain;
	private UISprite _sprite;



	void Awake()
	{
		_labelName = GetComponentsInChildren<UILabel>()[0];
		_labelCost = GetComponentsInChildren<UILabel>()[1];
		_labelGain = GetComponentsInChildren<UILabel>()[2];

		_sprite = GetComponentInChildren<UISprite>();

		Sprite = "";
		LabelName = "";
		LabelCost = "";
		LabelGain = "";
	}


	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
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

	public string LabelCost
	{
		get { return _labelCost.text; }
		set
		{
			if (String.IsNullOrEmpty(value))
			{
				_labelCost.text = "";
				_labelCost.enabled = false;
			}
			else
			{
				_labelCost.text = value;
				_labelCost.enabled = true;
			}
		}
	}
	public Color LabelCostColor
	{
		get { return _labelCost.color; }
		set { _labelCost.color = value; }
	}

	public string LabelGain
	{
		get { return _labelGain.text; }
		set
		{
			if (String.IsNullOrEmpty(value))
			{
				_labelGain.text = "";
				_labelGain.enabled = false;
			}
			else
			{
				_labelGain.text = value;
				_labelGain.enabled = true;
			}
		}
	}
	public Color LabelGainColor
	{
		get { return _labelGain.color; }
		set { _labelGain.color = value; }
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

