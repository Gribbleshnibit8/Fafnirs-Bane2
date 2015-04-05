using System;
using UnityEngine;
using System.Collections;

public class VitalBarBasic : MonoBehaviour
{
	public bool HasLabel = true;

	/// <summary>
	/// Maximum integer value that is represented by this bar
	/// </summary>
	public int MaxValue = 10;

	private UILabel _label;
	private UISlider _slider;

	/// <summary>
	/// Width of the bar when full
	/// </summary>
	private float _maxWidth;



	/// <summary>
	/// By how many units will the bar change with each step added or subtracted
	/// </summary>
	private int ValueStep;

	void Awake()
	{
		_slider = GetComponent<UISlider>();
		_label = GetComponentInChildren<UILabel>();

		if (_slider == null)
		{
			Debug.LogError("No _slider, needs one!");
			return;
		}

		if (HasLabel == false)
			_label.enabled = false;

		_maxWidth = _slider.foreground.localScale.x;

		ValueStep = (int) _maxWidth/MaxValue;
	}

	void Update()
	{
		//UpdateDisplay(MaxValue);
	}

	public void SetValues(int max)
	{
		MaxValue = max;
		ValueStep = (int)_maxWidth/max;
	}

	public void UpdateDisplay()
	{
		UpdateDisplay(1);
	}

	/// <summary>
	/// Takes a percentage value of the maximum out of 100.
	/// </summary>
	/// <param name="value"></param>
	public void UpdateDisplay(float value)
	{
		if (value > 1) value = 1;
		else if (value < 0) value = 0;

		var newSize = _slider.foreground.localScale;
		newSize.x = _maxWidth*value;
		_slider.foreground.localScale = newSize;

		string s = String.Format("{0:#0.#}/{1}", (value * MaxValue), MaxValue);
		_label.text = s;

	}




}
