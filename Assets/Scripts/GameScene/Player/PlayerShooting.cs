using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
	public GameObject m_BulletPrefab = null;
	public Transform[] m_GunTips;

	void Awake()
	{
		Debug.Assert( m_BulletPrefab, "Assign a BulletPrefab on the Inspector!" );
		Debug.Assert( m_GunTips.Length > 0, "GunTips array can't be zero length!" );
	}

	public void Shoot()
	{
		Debug.Log( "Bang!" );

		if( m_BulletPrefab )
		{
			for( int i = 0; i < m_GunTips.Length; i++ )
				Instantiate( m_BulletPrefab, m_GunTips[ i ].position, m_GunTips[ i ].rotation );
		}
	}
}
