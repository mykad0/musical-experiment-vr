using UnityEngine;
using System.Collections;

public class particleScript : MonoBehaviour {
	public	AudioSource					mySource;			// The principal AudioSource in the scene
	public	Material					particleMaterial;	// The material with a random color
	public	float						timeModulo;			// The number of seconds between 2 random color
	public	int							colorPrecision;		// The precision of the random color

	private	ParticleSystem.Particle		[]_particles;		// Array of particles
	private	int							_size;				// The number of particles of this ParticleSystem
	private	Color						_randomColor;
	private	float						_cpt = 0.0f;
	private	ParticleSystem				_myParticles;
	private	musicScript					_musicScript;
	
	void Start ()
	{
		_musicScript = mySource.GetComponent<musicScript> ();
		_randomColor = new Color((float)Random.Range(0, colorPrecision) / (float)colorPrecision, (float)Random.Range(0, colorPrecision) / (float)colorPrecision, (float)Random.Range(0, colorPrecision) / (float)colorPrecision, 1.0f);
		_myParticles = this.GetComponent<ParticleSystem> ();
	}
	
	void LateUpdate ()
	{
		if (Input.GetButtonDown("Fire1") && mySource.isPlaying == true)
			_myParticles.playbackSpeed = 0.0f;
		else if (Input.GetButtonDown("Fire1") && mySource.isPlaying == false)
			_myParticles.playbackSpeed = 1.0f;
		if (Time.time - _cpt > timeModulo && mySource.isPlaying == true)
		{
			_cpt = Time.time;
			_randomColor = new Color((float)Random.Range(0, colorPrecision) / (float)colorPrecision, (float)Random.Range(0, colorPrecision) / (float)colorPrecision, (float)Random.Range(0, colorPrecision) / (float)colorPrecision, 1.0f);			
		}
		_size = _myParticles.particleCount;
		_particles = new ParticleSystem.Particle[_size];
		_size = _myParticles.GetParticles(_particles);
		for (int i = 0; i < _size; i++)
		{
			_particles[i].size = Mathf.Lerp(_particles[i].size, _musicScript.rms * 2.0f + 0.1f, Time.smoothDeltaTime * 32.0f);
			_particles[i].velocity = new Vector3(0.0f, _musicScript.rms * 30.0f, 0.0f);
		}
		particleMaterial.SetColor("_Color", Color.Lerp(particleMaterial.color, _randomColor, Time.smoothDeltaTime));
		_myParticles.SetParticles(_particles, _size);
	}
}