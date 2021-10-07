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

        /// <summary>
        /// NPCのPrefabのパス
        /// </summary>
        private static string NPCPrefabPath = "Prefabs/NPC";

        // ↓AwakeのタイミングだとZenAutoInjecterが上手く動作しない
        //void Awake()
        // ↓Startのタイミングで行う
        void Start()
        {
            PhotonNetwork.Instantiate(PlayerPrefabPath, Vector3.zero, Quaternion.identity);

            if (PhotonNetwork.IsMasterClient)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector3 pos = new Vector3(Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f));
                    PhotonNetwork.Instantiate(NPCPrefabPath, pos, Quaternion.identity);
                }
            }
        }
    }
}
