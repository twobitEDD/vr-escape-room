﻿using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource _bgmSource;

    [SerializeField]
    private AudioSource _ambientSource;

    private AudioClipData _bgmClipData;

    private AudioClipData _ambientClipData;

    public void PlayBGM(AudioClipData clipData)
    {
        _bgmClipData = clipData;
        _bgmSource.clip = clipData.Clip;
        _bgmSource.volume = clipData.Volume;
        _bgmSource.loop = clipData.IsStaticLooped;
        _bgmSource.Play();
    }

    public void PlayAmbient(AudioClipData clipData)
    {
        _ambientClipData = clipData;
        _ambientSource.clip = clipData.Clip;
        _ambientSource.volume = clipData.Volume;
        _ambientSource.loop = clipData.IsStaticLooped;
        _ambientSource.Play();
    }

    private void Update()
    {
        if (_bgmClipData != null
            && _bgmClipData.IsDynamicLooped
            && _bgmSource.time > _bgmClipData.DynamicDuration)
        {
            _bgmSource.time = _bgmClipData.DynamicLoopTime;
        }
    }

    public AudioClipData TestBGMClipData;
    public AudioClipData TestAmbientClipData;

    private void Start()
    {
        if (TestBGMClipData)
        {
            PlayBGM(TestBGMClipData);
        }
        if (TestAmbientClipData)
        {
            PlayAmbient(TestAmbientClipData);
        }
    }
}