using UnityEngine;
using System.Collections.Generic;

// Notes:
// PoolOfObjects provides very simple way to handle object pooling
// of objects of any time. The only think object MUST have is a
// BackToPool_OnDisable component, and PoolOfObjects will check it and will
// and the component if it's not added yet.
// Configre pool using public fields and then use Spawn method in runtime

public class PoolOfObjects : MonoBehaviour
{
	public GameObject m_ObjectPrefab = null;
	public Transform m_ObjectsRoot = null;
	public int m_InitialPoolSize = 10;

	private Queue<GameObject> m_InactiveObjects = new Queue<GameObject>();

	void Awake()
	{
		Debug.Assert( m_ObjectsRoot, "Please assign an m_ObjectsRoot on the Inspector!" );
		Debug.Assert( m_ObjectPrefab, "Please assign an ObjectPrefab on the Inspector!" );
	}

	void Start()
	{
		for( int i = 0; i < m_InitialPoolSize; i++ )
		{
			GameObject new_obj = SpawnNew( Vector3.zero, Quaternion.identity );
			if( new_obj )
				new_obj.SetActive( false );
		}
	}
	
	public GameObject Spawn( Vector3 position, Quaternion rotation )
	{
		GameObject obj = null;

		if( m_InactiveObjects.Count > 0 )
		{
			obj = m_InactiveObjects.Dequeue();
			obj.transform.position = position;
			obj.transform.rotation = rotation;
			obj.SetActive( true );
		}
		else
		{
			obj = SpawnNew( position, rotation );
		}

		return obj;
	}

	public void OnChildDisable( GameObject obj )
	{
		m_InactiveObjects.Enqueue( obj );
	}

	public int GetActiveObjectsNum()
	{
		return this.transform.childCount - m_InactiveObjects.Count;
	}

	private GameObject SpawnNew( Vector3 position, Quaternion rotation )
	{
		GameObject obj = null;

		if( m_ObjectPrefab )
		{
			obj = Instantiate( m_ObjectPrefab, position, rotation ) as GameObject;

			if( m_ObjectsRoot )
			{
				obj.transform.SetParent( m_ObjectsRoot );
			}

			BackToPool_OnDisable comp = obj.GetComponent<BackToPool_OnDisable>() as BackToPool_OnDisable;
			if( comp == null )
			{
				comp = obj.AddComponent<BackToPool_OnDisable>();
			}

			if( comp != null )
			{
				comp.m_Pool = this;
			}
		}

		return obj;
	}
}
