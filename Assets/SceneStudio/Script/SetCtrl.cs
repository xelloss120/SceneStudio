using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneStudio
{
    /// <summary>
    /// プレイヤー以外のオブジェクトに操作を設定
    /// </summary>
    public class SetCtrl : SteamVR_Clench
    {
        /// <summary>
        /// 対象の位置を操作するオブジェクト
        /// </summary>
        [SerializeField]
        GameObject Position;

        /// <summary>
        /// 対象の回転を操作するオブジェクト
        /// </summary>
        [SerializeField]
        GameObject Rotation;

        /// <summary>
        /// 対象のシェイプを操作するオブジェクト
        /// </summary>
        [SerializeField]
        GameObject Shape;

        void Start()
        {
            Init();
            Set();
        }

        void Update()
        {
            if (IsClench())
            {
                Set();
            }
        }

        void Set()
        {
            var objects = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var obj in objects)
            {
                // 設定済みを飛ばす
                var check = obj.transform.Find(Position.name + "(Clone)");
                if (check != null)
                {
                    continue;
                }

                var heightMax = float.MinValue;
                var heightMaxVec3 = Vector3.zero;
                foreach (var child in obj.GetComponentsInChildren<Transform>())
                {
                    var mesh = child.GetComponent<SkinnedMeshRenderer>();
                    if (mesh == null)
                    {
                        // 回転操作
                        var rot = Instantiate(Rotation);
                        rot.GetComponent<ObjRot>().Target = child;
                        Set(rot, child, Rotation.transform.lossyScale);
                        if (heightMax < child.transform.position.y)
                        {
                            heightMax = child.transform.position.y;
                            heightMaxVec3 = child.transform.position;
                            heightMaxVec3.x -= 0.2f;
                        }
                    }
                }
                // 一番高い位置が欲しいので悲しみの二回
                foreach (var child in obj.GetComponentsInChildren<Transform>())
                {
                    var mesh = child.GetComponent<SkinnedMeshRenderer>();
                    if (mesh != null)
                    {
                        // ブレンドシェイプ
                        for (int i = 0; i < mesh.sharedMesh.blendShapeCount; i++)
                        {
                            var shape = Instantiate(Shape);
                            shape.transform.position = heightMaxVec3;
                            shape.transform.eulerAngles = new Vector3(0, Shape.transform.eulerAngles.y, 0);
                            shape.transform.localScale = Shape.transform.lossyScale;

                            var setShape = shape.GetComponent<ObjShape>();
                            var name = mesh.sharedMesh.GetBlendShapeName(i);
                            setShape.Init(mesh, i, name);

                            shape.GetComponent<SetParent>().Target = obj.transform;
                            shape.SetActive(true);

                            heightMaxVec3.y -= 0.02f;
                        }
                    }
                }

                // 位置操作
                var pos = Instantiate(Position);
                pos.GetComponent<ObjPos>().Target = obj.transform;
                Set(pos, obj.transform, Position.transform.lossyScale);
            }
        }

        void Set(GameObject obj, Transform parent, Vector3 scale)
        {
            obj.transform.position = parent.position;
            obj.transform.rotation = parent.rotation;
            obj.transform.localScale = scale;
            obj.transform.parent = parent;

            obj.GetComponent<SwitchingMaterial>().Target = parent;
            obj.GetComponent<SetParent>().Target = parent;

            obj.SetActive(true);
        }
    }
}
