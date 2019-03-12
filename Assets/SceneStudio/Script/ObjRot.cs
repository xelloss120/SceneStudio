using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// 対象の回転(掴んでいる時だけ)
    /// </summary>
    public class ObjRot : MonoBehaviour
    {
        /// <summary>
        /// 回転する対象
        /// </summary>
        public Transform Target;

        void Update()
        {
            transform.position = Target.position;

            if (transform.parent != null && transform.parent != Target)
            {
                Target.rotation = transform.rotation;
            }
        }
    }
}
