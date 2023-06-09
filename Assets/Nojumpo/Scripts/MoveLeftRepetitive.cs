using System;
using UnityEngine;

namespace Nojumpo
{
    public class MoveLeftRepetitive : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float moveSpeed;

        const float MAX_X_POSITION = -59.9f;
        const float INITIAL_X_POSITION = 59.9f;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Update() {

            if (transform.position.x <= MAX_X_POSITION)
            {
                transform.position = new Vector3(INITIAL_X_POSITION, transform.position.y, transform.position.z);
            }
        }

        void FixedUpdate() {
            transform.Translate(Vector3.left * moveSpeed * Time.fixedDeltaTime);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

    }
}
