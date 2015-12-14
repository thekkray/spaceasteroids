using UnityEngine;
using System.Collections;

[RequireComponent( typeof( ParticleSystem ) )]
public class DeactivateOnParticlesFinished : MonoBehaviour
{
	private ParticleSystem m_ParticleSystem = null;

	void Awake()
	{
		m_ParticleSystem = this.GetComponent<ParticleSystem>() as ParticleSystem;
		Debug.Assert( m_ParticleSystem, "ParticleSystem component not found!", this.gameObject );
	}

	void Update()
	{
		if( m_ParticleSystem && !m_ParticleSystem.IsAlive() )
			this.gameObject.SetActive( false );
	}
}
