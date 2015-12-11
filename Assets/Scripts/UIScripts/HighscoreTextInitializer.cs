using UnityEngine;
using UnityEngine.UI;

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
