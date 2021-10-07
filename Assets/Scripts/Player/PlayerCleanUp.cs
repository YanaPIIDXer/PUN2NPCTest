using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Player
{
    /// <summary>
    /// 切断されたプレイヤーのクリーンアップ監視
    /// </summary>
    [RequireComponent(typeof(PhotonView))]
    public class PlayerCleanUp : MonoBehaviour
    {
        /// <summary>
        /// PhotonView
        /// </summary>
        private PhotonView photonView = null;

        /// <summary>
        /// 前の所有者
        /// </summary>
        private Photon.Realtime.Player prevOwner = null;

        void Start()
        {
            photonView = GetComponent<PhotonView>();
            prevOwner = photonView.Owner;
        }

        void Update()
        {
            // 所有者が書き換わっていれば「元の所有者は切断した」と見做してオブジェクトを破棄する
            if (photonView.Owner != prevOwner)
            {
                Destroy(gameObject);
            }
        }
    }
}
