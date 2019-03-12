using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// HMD用カメラの表示レイヤーを切り替え
    /// </summary>
    public class HideCtrl : SteamVR_Clench
    {
        /// <summary>
        /// HMDのカメラ
        /// </summary>
        [SerializeField]
        Camera VRCamera;

        /// <summary>
        /// 非表示対象のレイヤー番号
        /// </summary>
        [SerializeField]
        int LayerNo;

        void Start()
        {
            Init();
        }

        void Update()
        {
            if (IsClench())
            {
                VRCamera.cullingMask ^= 1 << LayerNo;
            }
        }
    }
}
