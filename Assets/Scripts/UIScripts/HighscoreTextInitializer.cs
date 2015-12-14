using UnityEngine;
using UnityEngine.UI;

// Notes:
// Initializes UI text using current highscore
// Start content of text field will be using like format-string
// The component depends on PlayerPrefsHelper class

[RequireComponent( typeof( Text ) )]
public class HighscoreTextInitializer : MonoBehaviour
{
	private Text m_Text = null;

	void Awake()
	{
		m_Text = this.GetComponent<Text>() as Text;
		Debug.Assert( m_Text, "Text component not found!" );
	}

	void Start()
	{
		if( m_Text )
		{
			m_Text.text = string.Format( m_Text.text, PlayerPrefsHelper.GetHighscore() );
		}
	}
}
