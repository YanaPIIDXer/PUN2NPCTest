using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Zenject;
using Input;
using UniRx;

namespace Player
{
    /// <summary>
    /// プレイヤークラス
    /// </summary>
    [RequireComponent(typeof(PhotonView))]
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// 入力イベント
        /// </summary>
        [Inject]
        private IInputEvent inputEvent = null;

        /// <summary>
        /// 初期化が完了しているか？
        /// </summary>
        private bool bInitialized = false;

        /// <summary>
        /// 移動ベクトル
        /// </summary>
        private Vector2 moveVec = Vector2.zero;

        /// <summary>
        /// RigidBody
        /// </summary>
        private Rigidbody rigidBody = null;

        /// <summary>
        /// PhotonView
        /// </summary>
        private PhotonView photonView = null;

        void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
            photonView = GetComponent<PhotonView>();
        }

        void Update()
        {
            if (bInitialized) { return; }

            if (inputEvent != null)
            {
                inputEvent.OnMove
                          .Subscribe(vec =>
                          {
                              if (photonView.IsMine)
                              {
                                  moveVec = vec;
                              }
                          }).AddTo(gameObject);
                bInitialized = true;
            }
        }

        void FixedUpdate()
        {
            if (!photonView.IsMine) { return; }

            rigidBody.velocity = new Vector3(moveVec.x, 0.0f, moveVec.y);
        }
    }
}
