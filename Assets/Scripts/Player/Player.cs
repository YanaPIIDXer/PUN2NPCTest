using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Player
{
    /// <summary>
    /// プレイヤークラス
    /// </summary>
    [RequireComponent(typeof(PhotonView))]
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// 移動ベクトル
        /// </summary>
        private Vector2 moveVec = Vector2.zero;

        /// <summary>
        /// RigidBody
        /// </summary>
        private Rigidbody rigidBody = null;

        void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            moveVec.x = Input.GetAxisRaw("Horizontal");
            moveVec.y = Input.GetAxisRaw("Vertical");
        }

        void FixedUpdate()
        {
            rigidBody.velocity = new Vector3(moveVec.x, 0.0f, moveVec.y);
        }
    }
}
