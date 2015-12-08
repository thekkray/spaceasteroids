using UnityEngine;

public class PlayerPrefsHelper
{
	private static string m_HighscoreKey = "Highscore";

	public static int GetHighscore()
	{
		return PlayerPrefs.GetInt( m_HighscoreKey, 0 );
	}

	public static void SetHighscore( int highscore )
	{
		PlayerPrefs.SetInt( m_HighscoreKey, highscore );
	}
}
