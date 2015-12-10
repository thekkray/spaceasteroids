﻿using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
	public PoolOfObjects m_BulletsPool = null;
	public Transform[] m_GunTips;

	void Awake()
	{
		Debug.Assert( m_BulletsPool, "Assign a m_BulletsPool on the Inspector!" );
		Debug.Assert( m_GunTips.Length > 0, "GunTips array can't be zero length!" );
	}

	public void Shoot()
	{
		if( m_BulletsPool )
		{
			for( int i = 0; i < m_GunTips.Length; i++ )
			{
				m_BulletsPool.Spawn( m_GunTips[ i ].position, m_GunTips[ i ].rotation );
            }
		}
	}
}
