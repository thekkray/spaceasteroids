using UnityEngine;
using System.Collections.Generic;

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

	public void OnChildDisable( PoolableObject obj )
	{
		m_InactiveObjects.Enqueue( obj.gameObject );
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

			PoolableObject po = obj.GetComponent<PoolableObject>() as PoolableObject;
			if( po == null )
			{
				po = obj.AddComponent<PoolableObject>();
			}

			if( po != null )
			{
				po.m_PoolObject = this;
			}
		}

		return obj;
	}
}
