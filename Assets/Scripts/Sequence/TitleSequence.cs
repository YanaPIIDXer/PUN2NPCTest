using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Cysharp.Threading.Tasks;
using Pun2Task;
using System;
using Photon.Realtime;
using Photon.Pun;

namespace Sequence
{
    /// <summary>
    /// タイトルシーケンス
    /// </summary>
    public class TitleSequence : MonoBehaviour
    {
        /// <summary>
        /// スタートボタン
        /// </summary>
        [SerializeField]
        private Button startButton = null;

        void Awake()
        {
            startButton.OnClickAsObservable()
                       .Subscribe(async _ =>
                       {
                           startButton.interactable = false;
                           var token = this.GetCancellationTokenOnDestroy();
                           try
                           {
                               await Pun2TaskNetwork.ConnectUsingSettingsAsync(token);
                               Debug.Log("Connect OK");
                               await Pun2TaskNetwork.JoinOrCreateRoomAsync("TestRoom", new RoomOptions(), TypedLobby.Default, null, token);
                               Debug.Log("Room Join OK");
                               PhotonNetwork.LoadLevel("Game");
                           }
                           catch (Exception e)
                           {
                               startButton.interactable = true;
                               Debug.LogError(e.Message);
                           }
                       }).AddTo(gameObject);
        }
    }
}
