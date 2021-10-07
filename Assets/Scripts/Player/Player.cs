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
        private IInputEvent inputEvent = null;

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

        /// <summary>
        /// InputEventの注入
        /// </summary>
        /// <param name="inputEvent">InputEventインタフェース</param>
        [Inject]
        public void InjectInputEvent(IInputEvent inputEvent)
        {
            inputEvent.OnMove
                      .Subscribe(vec =>
                      {
                          if (photonView.IsMine)
                          {
                              moveVec = vec;
                          }
                      }).AddTo(gameObject);
        }

        void FixedUpdate()
        {
            if (!photonView.IsMine) { return; }

            rigidBody.velocity = new Vector3(moveVec.x, 0.0f, moveVec.y);
        }
    }
}
