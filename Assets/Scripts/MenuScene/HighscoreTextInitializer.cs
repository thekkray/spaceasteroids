using UnityEngine;
using UnityEngine.UI;

[RequireComponent( typeof( Text ) )]
public class HighscoreTextInitializer : MonoBehaviour
{
	void Start()
	{
		Text t = this.GetComponent<Text>() as Text;
		if( t )
		{
			t.text = string.Format( t.text, PlayerPrefsHelper.GetHighscore() );
		}
		else
		{
			Debug.LogError( "Text component not found!" );
		}
	}
}
