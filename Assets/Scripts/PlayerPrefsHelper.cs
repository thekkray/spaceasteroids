using UnityEngine;

// Notes:
// Helper class to have a single interface to saved-data
// I think it's much better than copy-pasting string-keys or
// having a shared list of string-constants.

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
