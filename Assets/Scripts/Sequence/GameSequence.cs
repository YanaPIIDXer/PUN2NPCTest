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

        // ↓AwakeのタイミングだとZenAutoInjecterが上手く動作しない
        //void Awake()
        // ↓Startのタイミングで行う
        void Start()
        {
            PhotonNetwork.Instantiate(PlayerPrefabPath, Vector3.zero, Quaternion.identity);
        }
    }
}
