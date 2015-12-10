using UnityEngine;
using System.Collections;

public class PooledObject : MonoBehaviour
{
	public ObjectsPool m_PoolObject = null;

	void Start()
	{
		Debug.Assert( m_PoolObject, "PoolObject object not defined!" );
	}

	void OnDisable()
	{
		m_PoolObject.OnChildDisable( this );
	}
}
