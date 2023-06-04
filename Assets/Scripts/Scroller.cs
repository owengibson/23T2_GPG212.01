using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPG212_01
{

    public class Scroller : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private void FixedUpdate()
        {
            transform.position += new Vector3(moveSpeed, 0f, 0f);

            moveSpeed += 0.00005f;
        }
    }
}