using UnityEngine;
using System.Collections;

/// <summary>
/// Game manager
/// Spawns Rocks and Player
/// Controlls progression through sessions
/// </summary>

public class GameManager : MonoBehaviour
{
	// conf
	public PoolOfObjects m_PoolOfLargeRocks = null;
	public Transform m_RockSpawnPointsParent = null;
	public HighscoreTextUpdater m_ScoreUpdater = null;
	public int m_RocksNumIncreaseStep = 0;
	public int m_ScoreForOneHit = 0;

	// private
	private int m_CurrentSessionIndex = -1;
	private int m_CurrentScore = 0;

	void Start()
	{
		Debug.Assert( m_PoolOfLargeRocks, "Assign a PoolOfLargeRocks on the Inspector!", this.gameObject );
		Debug.Assert( m_RockSpawnPointsParent, "Assign a RockSpawnPointsParent on the Inspector!", this.gameObject );
		Debug.Assert( m_RocksNumIncreaseStep != 0, "Rocks num should differ from zero!", this.gameObject );
		Debug.Assert( m_ScoreForOneHit != 0, "ScoreForOneHit num should differ from zero!", this.gameObject );
		Debug.Assert( m_ScoreUpdater, "Assign a ScoreUpdater on the Inspector!", this.gameObject );

		if( m_ScoreUpdater )
			m_ScoreUpdater.OnScoreChanged( m_CurrentScore );

		StartNextSession();
	}

	void OnEnable()
	{
		Bullet.OnBulletHit += OnBulletHit;
	}

	void OnDisable()
	{
		Bullet.OnBulletHit -= OnBulletHit;
	}

	void OnBulletHit( Transform transform )
	{
		m_CurrentScore += m_ScoreForOneHit;

		if( m_ScoreUpdater )
			m_ScoreUpdater.OnScoreChanged( m_CurrentScore );

        Debug.LogFormat( "TODO: fx at {0}",transform.position );
		// todo: создать эффект в этой точке
	}

	public void StartNextSession()
	{
		m_CurrentSessionIndex++;

		if( m_RockSpawnPointsParent && m_PoolOfLargeRocks )
		{
			int rocks_num = m_RocksNumIncreaseStep * ( m_CurrentSessionIndex + 1 );

			for( int i = 0; i < rocks_num ; i++ )
			{
				int rnd_index = Random.Range( 0, m_RockSpawnPointsParent.childCount );
				Transform t = m_RockSpawnPointsParent.GetChild( rnd_index );
				m_PoolOfLargeRocks.Spawn( t.position, t.rotation );
			}
		}
	}
}
