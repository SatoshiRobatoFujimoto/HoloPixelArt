using HoloPixelArt.Messages;
using HoloToolkitExtensions.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HoloToolkit.Unity.InputModule;
using HoloToolkitExtensions.Utilies;

namespace HoloPixelArt
{
    public class PixelManager : MonoBehaviour
    {
        public int GridSize = 10;
        public GameObject Pixel;
        public AudioClip GridReady;
        public BaseRayStabilizer Stabilizer = null;

        private bool isGridCreated;
        private AudioSource _audioSource;
        private List<GameObject> _pixels = new List<GameObject>();
        private float spacing;


        // Use this for initialization
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            spacing = Pixel.transform.localScale.x;
            Messenger.Instance.AddListener<CreateNewGridMessage>(m => CreateNewGrid());
            Messenger.Instance.AddListener<ChangeColorMessage>(ProcessChangeColorMessage);
        }

        // Update is called once per frame
        void Update()
        {
            if (!isGridCreated)
            {
                CreateGrid(LookingDirectionHelpers.CalculatePositionDeadAhead(2.0f));
                isGridCreated = true;
            }
        }

        private void CreatePixel(Vector3 position, Quaternion rotation)
        {
            var p = Instantiate(Pixel, position, rotation);
            var m = p.GetComponent<PixelManipulator>();
            //p.transform.RotateAround(position, transform.up, 180f);
            p.transform.parent = transform; 
            _pixels.Add(p);
        }

        private void CreateNewGrid()
        {
            foreach (var p in _pixels)
            {
                Destroy(p);
            }
            _pixels.Clear();
            isGridCreated = false;
        }

        private void CreateGrid(Vector3 hitPosition)
        {
            _audioSource.PlayOneShot(GridReady);

            var gazeOrigin = Camera.main.transform.position;
            var rotation = Camera.main.transform.rotation;

            var maxDistance = Vector3.Distance(gazeOrigin, hitPosition);

            transform.position = hitPosition;
            transform.rotation = rotation;

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    var pixelPosition = gazeOrigin + transform.forward * (hitPosition.z) + transform.right * (i* spacing) + transform.up * (j * spacing);
                    CreatePixel(pixelPosition, rotation);
                }
            }
        }

        private void ProcessChangeColorMessage(ChangeColorMessage msg)
        {
            foreach (var p in _pixels)
            {
                p.GetComponent<PixelManipulator>().ChangeColor(msg.Color);
            }
        }

        private PixelManipulator GetObjectLookedAt()
        {
            if (GazeManager.Instance.IsGazingAtObject)
            {
                return GazeManager.Instance.HitInfo.collider.gameObject.GetComponent<PixelManipulator>();
            }
            return null;
        }

    }
}

