using UnityEngine;

public class BackToPool_OnDisable : MonoBehaviour
{
	public PoolOfObjects m_Pool = null;

	void OnDisable()
	{
		Debug.Assert( m_Pool, "m_Pool object not defined!" );

		if( m_Pool )
			m_Pool.OnChildDisable( this.gameObject );
	}
}
