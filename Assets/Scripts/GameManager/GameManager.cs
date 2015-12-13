using UnityEngine;
using System.Collections;

/// <summary>
/// Game manager
/// Spawns Rocks and Player
/// Controlls progression through sessions, player death and fxs
/// </summary>

public class GameManager : MonoBehaviour
{
	// conf
	public PoolOfObjects m_PoolOfStartRocks = null;
	public int m_StartRocksNum = 0;
	public int m_RocksNumIncreaseStep = 0;

	public Transform m_RockSpawnPointsParent = null;
	public HighscoreTextUpdater m_ScoreUpdater = null;
	public int m_ScoreForOneHit = 0;
	public RockReplacementsRule[] m_ReplacementsRules;

	public PlayerMoving m_PlayerMovingController = null;
	public GameObject m_NewSessionFX = null;
	public GameObject m_PlayerDeathFX = null;
	public GameObject m_GameOverScreen = null;

	// private
	private int m_CurrentSessionIndex = -1;
	private int m_CurrentScore = 0;
	private int m_ActiveRocksNum = 0;
	private bool m_GameStarted = false;

	void Start()
	{
		Debug.Assert( m_PoolOfStartRocks, "Assign a PoolOfStartRocks on the Inspector!", this.gameObject );
		Debug.Assert( m_RockSpawnPointsParent, "Assign a RockSpawnPointsParent on the Inspector!", this.gameObject );
		Debug.Assert( m_StartRocksNum != 0, "m_StartRocksNum should differ from zero!", this.gameObject );
		Debug.Assert( m_RocksNumIncreaseStep != 0, "Rocks num should differ from zero!", this.gameObject );
		Debug.Assert( m_ScoreForOneHit != 0, "ScoreForOneHit num should differ from zero!", this.gameObject );
		Debug.Assert( m_ScoreUpdater, "Assign a ScoreUpdater on the Inspector!", this.gameObject );
		Debug.Assert( m_ReplacementsRules.Length > 0, "Please fill ReplacementsRules array!", this.gameObject );
		Debug.Assert( m_PlayerMovingController, "Assign a PlayerMoving on the Inspector!", this.gameObject );
		Debug.Assert( m_NewSessionFX, "Assign a NewSessionFX object on the Inspector!", this.gameObject );
		Debug.Assert( m_PlayerDeathFX, "Assign a PlayerDeathFX object on the Inspector!", this.gameObject );
		Debug.Assert( m_GameOverScreen, "Assign a GameOverScreen object on the Inspector!", this.gameObject );

		if( m_ScoreUpdater )
			m_ScoreUpdater.OnScoreChanged( m_CurrentScore );

		m_GameStarted = true;
		StartNextSession();
	}

	void OnEnable()
	{
		Bullet.OnBulletHit += OnBulletHit;
		Rock.OnRockHit += OnRockHit;
		Rock.OnRockEnabled += OnRockEnabled;
		Rock.OnRockDisabled += OnRockDisabled;
	}

	void OnDisable()
	{
		Bullet.OnBulletHit -= OnBulletHit;
		Rock.OnRockHit -= OnRockHit;
		Rock.OnRockEnabled -= OnRockEnabled;
		Rock.OnRockDisabled -= OnRockDisabled;
	}

	void OnBulletHit( Bullet bullet, Collider2D other )
	{
		if( other )
		{
			Rock rock = other.GetComponent<Rock>() as Rock;
			if( rock )
			{
				OnRockDestroyed( rock );

				bullet.gameObject.SetActive( false );
				rock.gameObject.SetActive( false );

				m_CurrentScore += m_ScoreForOneHit;

				if( m_CurrentScore > PlayerPrefsHelper.GetHighscore() )
					PlayerPrefsHelper.SetHighscore( m_CurrentScore );

				if( m_ScoreUpdater )
					m_ScoreUpdater.OnScoreChanged( m_CurrentScore );
			}
        }

		Debug.LogFormat( "TODO: fx at {0}", bullet.transform.position );
	}

	void OnRockHit( Rock rock, Collider2D other )
	{
		if( other.CompareTag("Player") )
		{
			other.gameObject.SetActive( false );

			if( m_GameOverScreen )
				m_GameOverScreen.SetActive( true );
		}
	}

	void OnRockDestroyed( Rock rock )
	{
		for( int rule_i = 0; rule_i < m_ReplacementsRules.Length; rule_i++ )
		{
			if( m_ReplacementsRules[ rule_i ].m_OriginalRockSize == rock.m_Size )
			{
				int new_rocks_num = m_ReplacementsRules[ rule_i ].m_NewRocksCount;

				PoolOfObjects pool = m_ReplacementsRules[ rule_i ].m_PoolOfNewRocks;
				if( pool )
				{
					for( int rock_i = 0; rock_i < new_rocks_num; rock_i++ )
					{
						pool.Spawn( rock.transform.position, Quaternion.identity );
					}
				}
            }
		}
	}

	void OnRockEnabled( Rock rock )
	{
		m_ActiveRocksNum++;
	}
	
	void OnRockDisabled( Rock rock )
	{
		m_ActiveRocksNum--;

		if( m_ActiveRocksNum <= 0 )
		{
			StartNextSession();
		}
	}

	public void StartNextSession()
	{
		if( !m_GameStarted )
			return;

		m_CurrentSessionIndex++;

		if( m_RockSpawnPointsParent && m_PoolOfStartRocks )
		{
			int rocks_num = m_StartRocksNum + m_RocksNumIncreaseStep * m_CurrentSessionIndex;

			for( int i = 0; i < rocks_num ; i++ )
			{
				int rnd_index = Random.Range( 0, m_RockSpawnPointsParent.childCount );
				Transform t = m_RockSpawnPointsParent.GetChild( rnd_index );
				m_PoolOfStartRocks.Spawn( t.position, t.rotation );
			}
		}

		if( m_PlayerMovingController )
			m_PlayerMovingController.ResetToStartPosition();

		Debug.Log( "NewSessionFX" );

		if( m_NewSessionFX )
			m_NewSessionFX.SetActive( true );
	}
}
