using UnityEngine;
using UnityEngine.UI;

[RequireComponent( typeof( Text ) )]
public class HighscoreTextUpdater : MonoBehaviour
{
	private Text m_Text = null;

	void Awake()
	{
		m_Text = this.GetComponent<Text>() as Text;
		Debug.Assert( m_Text, "Text component not found!" );
	}

	public void OnScoreChanged( int new_score )
	{
		if( m_Text )
			m_Text.text = new_score.ToString();
	}
}
