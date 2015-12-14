using UnityEngine;

// Notes:
// Deactivates a gameobject it's connected to when ParticleSystem is
// not alive anymore.
// In AsteroidsTest I use to disable particle to let other component move it back to a pool

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
