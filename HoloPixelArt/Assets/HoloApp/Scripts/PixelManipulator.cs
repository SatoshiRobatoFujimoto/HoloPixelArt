using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HoloPixelArt
{
    public class PixelManipulator : MonoBehaviour, IInputClickHandler
    {
        public int Id;
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
            if(Click != null)
            {
                _audioSource.PlayOneShot(Click);
            }
            _renderer.material.color = _color; 
        }
    }
}
