using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// プレイヤー基点の高さ調整
    /// </summary>
    public class PlayerHeight : SteamVR_Vector2
    {
        /// <summary>
        /// SteamVR Plugin2系のPlayer Prefab想定
        /// </summary>
        [SerializeField]
        Transform Player;

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
                Player.position += new Vector3(0, Axis.y, 0) * Player.localScale.x * Gain;
            }
        }
    }
}
