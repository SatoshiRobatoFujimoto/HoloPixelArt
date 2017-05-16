using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HoloPixelArt
{
    public class PixelManipulator : MonoBehaviour, IInputClickHandler
    {
        public AudioClip Click;

        private AudioSource _audioSource;
        private Renderer _renderer;
        private Color _color;

        // Use this for initialization
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _renderer = GetComponent<Renderer>();
            _color = Color.blue;
        }

        public void ChangeColor(Color color)
        {
            _color = color;
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            _audioSource.PlayOneShot(Click);
            if(_renderer.material.color == Color.white)
            {
                _renderer.material.color = _color;
            }
            else
            {
                _renderer.material.color = Color.white;
            }
        }
    }
}
