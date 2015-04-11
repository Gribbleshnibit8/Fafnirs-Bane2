using UnityEngine;
using System.Collections;

public class ConfirmMenu : MonoBehaviour
{

	private static int _confirmState = 0;

	/// <summary>
	/// Returns 1 if confirm button pressed, returns -1 if cancel button pressed, returns 0 otherwise.
	/// </summary>
	public static int ConfirmMenuState
	{
		get
		{
			switch (_confirmState)
			{
				case 1:
					_confirmState = 0;
					return 1;
				case -1:
					_confirmState = 0;
					return -1;
				default:
					return 0;
			}
		}
	}

	public void ConfirmAction()
	{
		_confirmState = 1;
	}

	public void CancelAction()
	{
		_confirmState = -1;
	}
}
