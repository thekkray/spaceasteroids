using UnityEngine;

/// <summary>
/// PlayerPrefsHelper
/// Helper class, stores all PlayerPrefs-keys and provides easy-to-use-methods
/// </summary>

public class PlayerPrefsHelper
{
	// private
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
