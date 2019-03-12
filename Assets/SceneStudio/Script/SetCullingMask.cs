using System.Collections.Generic;
using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// カメラの非表示対象を設定
    /// </summary>
    /// <remarks>
    /// インスペクタで設定すればいいけど、Prefab経由で使えるようにするため
    /// </remarks>
    public class SetCullingMask : MonoBehaviour
    {
        /// <summary>
        /// 対象のカメラ
        /// </summary>
        [SerializeField]
        Camera Target;

        /// <summary>
        /// 非表示対象のレイヤー番号
        /// </summary>
        [SerializeField]
        List<int> LayerNo;

        void Start()
        {
            foreach (var no in LayerNo)
            {
                Target.cullingMask &= ~(1 << no);
            }
        }
    }
}
