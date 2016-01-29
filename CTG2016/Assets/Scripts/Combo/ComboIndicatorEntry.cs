using UnityEngine;
using System.Collections;

public class ComboIndicatorEntry : MonoBehaviour {

	public Sprite spriteUp;
	public Sprite spriteDown;
	public Sprite spriteLeft;
	public Sprite spriteRight;

	public SpriteRenderer foreground;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetGraphics(Combo.Entry entry)
	{
		switch(entry)
		{
		case Combo.Entry.Up:
			foreground.sprite = spriteUp;
			break;
		case Combo.Entry.Down:
			foreground.sprite = spriteDown;
			break;
		case Combo.Entry.Left:
			foreground.sprite = spriteLeft;
			break;
		case Combo.Entry.Right:
			foreground.sprite = spriteRight;
			break;
		default:
			Debug.LogError("Invalid selector for UpdateGraphics. Cannot find sprite for Combo.Entry: " + entry.ToString());
			break;	
		}
	}
}
