using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cysharp.Threading.Tasks;
using Pun2Task;
using Cysharp.Threading.Tasks.Linq;

namespace Player
{
    /// <summary>
    /// 切断されたプレイヤーのクリーンアップ監視
    /// </summary>
    [RequireComponent(typeof(PhotonView))]
    public class PlayerCleanUp : MonoBehaviour
    {
        /// <summary>
        /// 所有者
        /// ※OnPlayerLeftRoomが走るタイミングではPhotonView.Ownerは既に書き換えられているため、
        /// 　あらかじめキャッシュしておく
        /// </summary>
        private Photon.Realtime.Player owner = null;

        void Start()
        {
            var photonView = GetComponent<PhotonView>();
            owner = photonView.Owner;
            Watch().Forget();
        }

        /// <summary>
        /// 監視
        /// </summary>
        private async UniTaskVoid Watch()
        {
            await Pun2TaskCallback.OnPlayerLeftRoomAsyncEnumerable()
                                  .ForEachAsync((player) =>
                                  {
                                      if (player == owner)
                                      {
                                          Destroy(gameObject);
                                      }
                                  }, this.GetCancellationTokenOnDestroy());
        }
    }
}
