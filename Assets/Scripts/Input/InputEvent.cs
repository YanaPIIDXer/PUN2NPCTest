using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Input
{
    /// <summary>
    /// 入力イベントインタフェース
    /// </summary>
    public interface IInputEvent
    {
        /// <summary>
        /// 移動
        /// </summary>
        IObservable<Vector2> OnMove { get; }
    }
}
