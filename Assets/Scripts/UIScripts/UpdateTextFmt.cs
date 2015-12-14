using UnityEngine;
using UnityEngine.UI;

// Notes:
// Provides the way to update any UI-Text in runtime
// Now provide only one method for one parameter of int type
// but can be easily extended to work with a number of different
// parameters
// In this test-task I use this component to update player lives num and a current score

[RequireComponent( typeof( Text ) )]
public class UpdateTextFmt : MonoBehaviour
{
	[TextArea]
	public string m_Format = "{0}";
	public bool m_UseTextAsFormat = true;

	private Text m_Text = null;

	void Awake()
	{
		m_Text = this.GetComponent<Text>() as Text;
		Debug.Assert( m_Text, "Text component not found!" );

		if( m_UseTextAsFormat && m_Text )
			m_Format = m_Text.text;
	}

	public void UpdateText( int new_score )
	{
		if( m_Text )
			m_Text.text = string.Format( m_Format, new_score );
	}
}
