using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// プレイヤー基点の向き調整
    /// </summary>
    public class PlayerRot : SteamVR_Vector2
    {
        /// <summary>
        /// SteamVR Plugin2系のPlayer Prefab想定
        /// </summary>
        [SerializeField]
        Transform Player;

        /// <summary>
        /// 視点の向き(視点方向に前進させるため)
        /// </summary>
        [SerializeField]
        Transform VRCamera;

        /// <summary>
        /// 速さ調整
        /// </summary>
        [SerializeField]
        float Gain;

        void Start()
        {
            Init();
        }

        void Update()
        {
            if (UpdateAxis())
            {
                Player.RotateAround(VRCamera.position, Vector3.up, Axis.x * Player.localScale.x * Gain);
            }
        }
    }
}
