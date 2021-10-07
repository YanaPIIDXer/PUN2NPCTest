using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Input
{
    /// <summary>
    /// キー入力
    /// </summary>
    public class KeyInput : MonoBehaviour, IInputEvent
    {
        /// <summary>
        /// 移動プロパティ
        /// </summary>
        private ReactiveProperty<Vector2> onMoveProp = new ReactiveProperty<Vector2>(Vector2.zero);

        /// <summary>
        /// 移動した
        /// </summary>
        public IObservable<Vector2> OnMove => onMoveProp;

        void Update()
        {
            Vector2 moveVec = Vector2.zero;
            moveVec.x = UnityEngine.Input.GetAxisRaw("Horizontal");
            moveVec.y = UnityEngine.Input.GetAxisRaw("Vertical");
            onMoveProp.Value = moveVec;
        }
    }
}
