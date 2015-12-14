using UnityEngine;

// Notes:
// The only thing this component does is a notification
// of master pool about disabling one of it's object to let
// the pool move it to inactive-object list.

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
