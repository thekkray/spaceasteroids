using UnityEngine;
using UnityEngine.UI;

[RequireComponent( typeof( Text ) )]
public class HighscoreTextUpdater : MonoBehaviour
{
	private Text m_Text = null;

	void Awake()
	{
		m_Text = this.GetComponent<Text>() as Text;
		if( m_Text == null )
			Debug.LogError( "Text component not found!" );
	}

	void OnScoreChanged( int new_score )
	{
		if( m_Text )
			m_Text.text = new_score.ToString();
	}
}
