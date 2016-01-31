using UnityEngine;
using System.Collections;

public class WillyInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public enum JoystickButton
	{
		A,
		B,
		X,
		Y,
	}

	public static bool IsJoystickButtonPressed(JoystickButton button)
	{
		switch (button)
		{
		case JoystickButton.A:
			#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
			return Input.GetKeyDown("joystick button 16");
			#else
			return Input.GetKeyDown("joystick button 0");
			#endif
		case JoystickButton.B:
			#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
			return Input.GetKeyDown("joystick button 17");
			#else
			return Input.GetKeyDown("joystick button 1");
			#endif
		case JoystickButton.X:
			#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
			return Input.GetKeyDown("joystick button 18");
			#else
			return Input.GetKeyDown("joystick button 2");
			#endif
		case JoystickButton.Y:
			#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
			return Input.GetKeyDown("joystick button 19");
			#else
			return Input.GetKeyDown("joystick button 3");
			#endif
		}

		return false;
	}
}
