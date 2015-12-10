using UnityEngine;
using System.Collections.Generic;

public class ObjectsPool : MonoBehaviour
{
	public GameObject m_ObjectPrefab = null;
	public Transform m_ObjectsRoot = null;

	private Queue<GameObject> m_InactiveObjects = new Queue<GameObject>();

	void Awake()
	{
		Debug.Assert( m_ObjectsRoot, "Please assign an m_ObjectsRoot on the Inspector!" );
		Debug.Assert( m_ObjectPrefab, "Please assign an ObjectPrefab on the Inspector!" );
	}

	void Start()
	{
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
			if( m_ObjectPrefab )
			{
				obj = Instantiate( m_ObjectPrefab, position, rotation ) as GameObject;

				if( m_ObjectsRoot )
				{
					obj.transform.SetParent( m_ObjectsRoot );
				}	

				PooledObject po = obj.GetComponent<PooledObject>() as PooledObject;
				if( po == null )
				{
					po = obj.AddComponent<PooledObject>();
				}

				if( po != null )
				{
					po.m_PoolObject = this;
				}
			}
		}

		return obj;
	}

	public void OnChildDisable( PooledObject obj )
	{
		m_InactiveObjects.Enqueue( obj.gameObject );
	}
}
