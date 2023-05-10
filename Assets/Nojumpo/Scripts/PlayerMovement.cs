using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Nojumpo
{
    public class PlayerMovement : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Rigidbody2D _playerRigidbody2D;
        Transform _playerTransform;
        Vector2 _movePosition;
        Vector2 _moveInput;
        Vector2 _smoothedMoveInput;
        float _moveInputSmoothVelocity;
        [SerializeField] float moveSpeed;
        [SerializeField] float rotationSpeed;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }

        void FixedUpdate() {
            HandlePlayerMovement();
            HandlePlayerRotation();
        }


        // ------------------------------ INPUT METHODS ----------------------------
        void OnMove(InputValue inputValue) {
            _moveInput = inputValue.Get<Vector2>();
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _playerRigidbody2D = GetComponent<Rigidbody2D>();
        }

        void HandlePlayerMovement() {
            _smoothedMoveInput.y = Mathf.SmoothDamp(
                _smoothedMoveInput.y,
                _moveInput.y,
                ref _moveInputSmoothVelocity,
                0.1f);

            _playerRigidbody2D.velocity = transform.up * (_smoothedMoveInput.y * moveSpeed);
        }

        void HandlePlayerRotation() {
            float rotation = -_moveInput.x * rotationSpeed;
            transform.Rotate(Vector3.forward * rotation);
        }
        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
    }
}
