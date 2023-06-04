using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GPG212_01
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Parameters")]
        public Element playerElement = Element.WATER;
        public KeyCode jumpKey = KeyCode.Space;
        public KeyCode switchElementKey = KeyCode.E;
        public KeyCode abilityKey = KeyCode.Return;
        [Space]

        [SerializeField] private float _jumpStrength;
        [Space]

        [SerializeField] private Color waterColor = new Color32(0, 137, 255, 255);
        [SerializeField] private Color fireColor = new Color32(255, 104, 0, 255);

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

            //Debug.Log((KeyCode)System.Enum.Parse(typeof(KeyCode), "Space"));
            jumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpKey"));
            switchElementKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("SwitchElementKey"));
        }

        private void Update()
        {
            if (Input.GetKey(jumpKey) && IsGrounded())
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0f);
                _isReadyToJump = true;
            }

            if (Input.GetKeyDown(switchElementKey))
            {
                if (playerElement == Element.WATER)
                {
                    playerElement = Element.FIRE;
                    _spriteRenderer.color = fireColor;
                }
                else
                {
                    playerElement = Element.WATER;
                    _spriteRenderer.color = waterColor;
                }
            }
        }

        private void FixedUpdate()
        {
            if (_isReadyToJump)
            {
                _rigidbody2D.AddRelativeForce(Vector2.up * _jumpStrength);
                _isReadyToJump = false;
            }

            _jumpStrength += 0.01f;
        }

        private bool IsGrounded()
        {
            bool isGrounded = Physics2D.Raycast(_spriteRenderer.bounds.min, Vector2.down, 0.05f, groundLayerMask);
            return isGrounded;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                if (Vector2.Angle(collision.contacts[i].normal, Vector2.left) <= 60f)
                {
                    EventManager.OnGameOver?.Invoke();
                }
            }
        }
    }
}