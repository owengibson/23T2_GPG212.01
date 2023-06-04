using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPG212_01
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Parameters")]
        public KeyCode jumpKey = KeyCode.Space;
        public KeyCode switchModeKey = KeyCode.Return;
        [Space]

        [SerializeField] private float _jumpStrength;

        [Space]
        [Header("References")]
        [SerializeField] private LayerMask groundLayerMask;

        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;

        private bool _isReadyToJump = false;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKey(jumpKey) && IsGrounded())
            {
                _isReadyToJump = true;
            }
        }

        private void FixedUpdate()
        {
            if (_isReadyToJump)
            {
                _rigidbody2D.velocity += new Vector2(0f, _jumpStrength);
                _isReadyToJump = false;
            }
        }

        private bool IsGrounded()
        {
            bool isGrounded = Physics2D.Raycast(_spriteRenderer.bounds.min, Vector2.down, 0.05f, groundLayerMask);
            return isGrounded;
        }
    }
}