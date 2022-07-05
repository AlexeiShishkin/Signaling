using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private float _switchingDuration;

    private const float _maxVolume = 1;
    private const float _minVolume = 0;

    private AudioSource _audio;
    private Coroutine _switching;

    public void Play()
    {
        _audio.Play();
        StartSwitching(StartPlaying());
    }

    public void Stop()
    {
        StartSwitching(StartStopping());
    }

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = _minVolume;
    }

    private void StartSwitching(IEnumerator routine)
    {
        if (_switching != null)
        {
            StopCoroutine(_switching);
        }
        
        _switching = StartCoroutine(routine);
    }

    private IEnumerator StartPlaying()
    {
        yield return StartCoroutine(Switch(_maxVolume));

        _switching = null;
    }

    private IEnumerator StartStopping()
    {
        yield return StartCoroutine(Switch(_minVolume));

        _audio.Stop();
        _switching = null;
    }

    private IEnumerator Switch(float targetVolume)
    {
        float switchingRate = _maxVolume / _switchingDuration;

        while (_audio.volume != targetVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, targetVolume, switchingRate * Time.deltaTime);

            yield return null;
        }
    }
}
