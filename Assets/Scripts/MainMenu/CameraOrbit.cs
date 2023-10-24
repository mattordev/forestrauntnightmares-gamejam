using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mattordev.menu
{
    public class CameraOrbit : MonoBehaviour
    {
        public float speed; // The speed of the orbit
        public GameObject mainCamera;
        public GameObject orbitPoint;
        public bool doOrbit;

        // Update is called once per frame
        void Update()
        {
            if (doOrbit)
            {
                OrbitCamera();
            }
        }

        public void OrbitCamera()
        {
            transform.RotateAround(orbitPoint.transform.position, Vector3.down, speed * Time.deltaTime);
            transform.LookAt(orbitPoint.transform.position);
        }
    }
}

