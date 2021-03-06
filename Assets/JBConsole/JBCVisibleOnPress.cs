using UnityEngine;

[RequireComponent(typeof(JBConsole))]
public class JBCVisibleOnPress : MonoBehaviour {
	
	public KeyCode key = KeyCode.BackQuote;
	
	JBConsole console;
	
	public float secsRequiredToPress = 1f;
	public Rect pressArea = new Rect(0, 0, 100, 100);
	
	float secsPressed;
	
	void Start ()
	{
		console = GetComponent<JBConsole>();
	}
	
	void Update ()
	{
		if(Input.GetMouseButton(0))
		{
			pressArea.y = Screen.height - pressArea.height;
			if(pressArea.Contains(Input.mousePosition))
			{
				secsPressed += Time.deltaTime;
				if(secsPressed >= secsRequiredToPress)
				{
					console.Visible = true;
					secsPressed = 0;
				}
			}
		}
		else
		{
			secsPressed = 0;
		}
	}
	
	public static JBCVisibleOnPress RegisterToConsole()
	{
		if(JBConsole.Exists)	
		{
			return JBConsole.instance.RegisterPlugin<JBCVisibleOnPress>();
		}
		return null;
	}
}
