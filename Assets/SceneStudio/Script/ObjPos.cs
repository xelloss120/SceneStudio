using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// 対象の移動
    /// </summary>
    public class ObjPos : MonoBehaviour
    {
        /// <summary>
        /// 対象に対して表示位置をズラす差
        /// </summary>
        public Vector3 Offset;

        /// <summary>
        /// 移動する対象
        /// </summary>
        public Transform Target;

        void Update()
        {
            if (transform.parent != null && transform.parent != Target)
            {
                Target.position = transform.position + Offset;
            }
            else
            {
                transform.position = Target.position - Offset;
            }
        }
    }
}
