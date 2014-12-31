using UnityEngine;
using System.Collections;

public class musicScript : MonoBehaviour {
	public	float			rms;			// The "power" of the music at a certain time, used for the scale of the particles 
	public	float			logScale;		// A constant value which modify the size of the spectrum analyser
	public	int				precision;		// The number of bars used by the power analyser
	public	GameObject		prefab;			// The prefab used for the bars

	private	float			[]_samples1;	// The array used for the power of the left channel of the music
	private	float			[]_samples2;	// The array used for the power of the right channel of the music
	private	float			[]_spectrum;	// The array used for the spectrum data of the music
	private	AudioSource		_mySource;		// The audiosource
	private	GameObject		[]_bars;		// The array of objects used by the spectrum analyser
	private	GameObject		[]_barsOutput;  // The array of objects used by the power analyser
	
	void Start ()
	{
		Screen.lockCursor = true;
		_samples1 = new float[precision];
		_samples2 = new float[precision];
		_spectrum = new float[64];
		_mySource = this.GetComponent<AudioSource> ();
		_bars = new GameObject[64];
		_barsOutput = new GameObject[precision];
		// Instantiate all the objects, using an logarithmic scale for the spectrum analyser
		for (int i = 0; i < 64; i++)
		{
			_bars[i] = GameObject.Instantiate(prefab, new Vector3(-16.0f + (Mathf.Log((float)i + 1.0f) * logScale), 10.0f, 24.0f), Quaternion.identity) as GameObject;
			_bars[i].transform.localScale = new Vector3((logScale) / ((float)i + 1.0f), 1.0f, 1.0f);
		}
		for (int i = 0; i < precision; i++)
		{
			_barsOutput[i] = GameObject.Instantiate(prefab, new Vector3(16.0f - (i * (32.0f / (float)precision)), 10.0f, -24.0f), Quaternion.identity) as GameObject;	
			_barsOutput[i].transform.localScale = new Vector3(32.0f / (float)precision, 1.0f, 1.0f);
		}
	}
	
	void Update ()
	{
		rms = 0.0f;
		if (Input.GetButtonDown("Fire1") && _mySource.isPlaying == true)
			_mySource.Pause();
		else if (Input.GetButtonDown("Fire1") && _mySource.isPlaying == false)
			_mySource.Play();
		_mySource.GetOutputData(_samples1, 0);
		_mySource.GetOutputData(_samples2, 1);
		_mySource.GetSpectrumData(_spectrum, 0, FFTWindow.Rectangular);
		for (int i = 0; i < 64; i++)
			_bars[i].transform.localScale = Vector3.Lerp(_bars[i].transform.localScale, new Vector3(_bars[i].transform.localScale.x, _spectrum[i] * 16.0f * ((float)i + 1.0f), 1.0f), Time.smoothDeltaTime * 16.0f);
		for (int i = 0; i < precision; i++)
		{
			_barsOutput[i].transform.localScale = Vector3.Lerp(_barsOutput[i].transform.localScale, new Vector3(32.0f / (float)precision, (_samples1[i] + _samples2[i]) * 10.0f, 1.0f), Time.smoothDeltaTime * 16.0f);
			rms += Mathf.Pow((_samples1[i] + _samples2[i]) / 1.5f, 2.0f);
		}
		rms = Mathf.Sqrt(rms / (float)precision);
	}
}
