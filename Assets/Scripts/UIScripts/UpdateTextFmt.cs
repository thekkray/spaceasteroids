using UnityEngine;
using UnityEngine.UI;

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
