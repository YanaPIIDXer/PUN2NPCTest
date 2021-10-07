using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Pun2Task;
using Cysharp.Threading.Tasks;

namespace NPC
{
    /// <summary>
    /// NPCのPhotonView所有権管理
    /// </summary>
    [RequireComponent(typeof(PhotonView))]
    public class NPCOwnership : MonoBehaviour
    {
        /// <summary>
        /// PhotonView
        /// </summary>
        private PhotonView photonView = null;

        void Awake()
        {
            photonView = GetComponent<PhotonView>();
            UpdateOwnership().Forget();
        }

        /// <summary>
        /// 所有権の更新
        /// </summary>
        private async UniTaskVoid UpdateOwnership()
        {
            await Pun2TaskCallback.OnMasterClientSwitchedAsync();
            if (PhotonNetwork.IsMasterClient)
            {
                await photonView.RequestOwnershipAsync(this.GetCancellationTokenOnDestroy());
                Debug.Log("Got Ownership!");
            }
            UpdateOwnership().Forget();     // 次に変わった時の為に次を走らせておく
        }
    }
}
