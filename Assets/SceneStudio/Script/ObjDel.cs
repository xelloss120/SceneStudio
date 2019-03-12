using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// 削除対象に合わせて削除
    /// </summary>
    public class ObjDel : SteamVR_Clench
    {
        /// <summary>
        /// 位置操作
        /// </summary>
        [SerializeField]
        GameObject Position;

        /// <summary>
        /// 画像表示
        /// </summary>
        [SerializeField]
        GameObject Photo;

        void Start()
        {
            Init();
        }

        void OnTriggerStay(Collider other)
        {
            if (IsClench())
            {
                var name = other.gameObject.name;

                if (name == Position.name + "(Clone)")
                {
                    Destroy(other.gameObject.transform.parent.gameObject);
                }

                if (name == Photo.name + "(Clone)")
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
