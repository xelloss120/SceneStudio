using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// プレイヤー基点の位置調整
    /// </summary>
    public class PlayerPos : SteamVR_Vector2
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
                var vec3 = VRCamera.rotation * new Vector3(Axis.x, 0, Axis.y);
                Player.position += vec3 * Player.localScale.x * Gain;
            }
        }
    }
}
