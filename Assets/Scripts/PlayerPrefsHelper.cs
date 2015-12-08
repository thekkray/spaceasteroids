using UnityEngine;
using System.Collections;

public class PlayerPrefsHelper : MonoBehaviour
{
	private string m_HighscoreKey = "Highscore";

	int GetHighscore()
	{
		return PlayerPrefs.GetInt( m_HighscoreKey, 0 );
	}

	void SetHighscore( int highscore )
	{
		PlayerPrefs.SetInt( m_HighscoreKey, highscore );
	}
}
