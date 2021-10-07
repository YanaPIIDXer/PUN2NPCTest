using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace NPC
{
    /// <summary>
    /// NPCの移動
    /// </summary>
    [RequireComponent(typeof(PhotonView))]
    public class NPCMove : MonoBehaviour
    {
        /// <summary>
        /// PhotonView
        /// </summary>
        private PhotonView photonView = null;

        /// <summary>
        /// 現在の座標
        /// </summary>
        private Vector3 currentPosition = Vector3.zero;

        /// <summary>
        /// 次の座標
        /// </summary>
        private Vector3 nextPosition = Vector3.zero;

        /// <summary>
        /// 移動時間
        /// </summary>
        private float moveTime = 1.0f;

        void Awake()
        {
            photonView = GetComponent<PhotonView>();
            currentPosition = transform.position;
            nextPosition = currentPosition;
        }

        void Update()
        {
            if (!photonView.IsMine) { return; }

            if (moveTime >= 1.0f)
            {
                currentPosition = transform.position;
                nextPosition = currentPosition + new Vector3(Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f));
                moveTime = 0.0f;
            }

            moveTime = Mathf.Min(moveTime + Time.deltaTime, 1.0f);
            transform.position = Vector3.Lerp(currentPosition, nextPosition, moveTime);
        }
    }
}
