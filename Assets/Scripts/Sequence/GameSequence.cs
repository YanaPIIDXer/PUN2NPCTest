using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Sequence
{
    /// <summary>
    /// ゲームシーケンス
    /// </summary>
    public class GameSequence : MonoBehaviour
    {
        /// <summary>
        /// プレイヤーのPrefabのパス
        /// </summary>
        private static string PlayerPrefabPath = "Prefabs/Player";

        void Awake()
        {
            PhotonNetwork.Instantiate(PlayerPrefabPath, Vector3.zero, Quaternion.identity);
        }
    }
}
