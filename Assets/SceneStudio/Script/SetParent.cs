using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// 親を持たない場合は対象を親に設定
    /// </summary>
    /// <remarks>
    /// 掴んで離すと親無しになるのがSteamVR Plugin 2以降の仕様っぽい？
    /// </remarks>
    public class SetParent : MonoBehaviour
    {
        /// <summary>
        /// 対象
        /// </summary>
        public Transform Target;

        void Update()
        {
            if (transform.parent == null)
            {
                transform.parent = Target;
            }
        }
    }
}
