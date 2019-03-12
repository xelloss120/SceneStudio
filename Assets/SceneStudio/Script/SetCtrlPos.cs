using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace SceneStudio
{
    /// <summary>
    /// 操作用オブジェクトの位置調整
    /// </summary>
    public class SetCtrlPos : MonoBehaviour
    {
        /// <summary>
        /// トリガー入力の取得元
        /// </summary>
        [SerializeField]
        SteamVR_Action_Boolean GrabPinch;

        /// <summary>
        /// グリップ入力の取得元
        /// </summary>
        [SerializeField]
        SteamVR_Action_Boolean GrabGrip;

        /// <summary>
        /// 画像撮影用カメラ
        /// </summary>
        [SerializeField]
        GameObject Camera;

        /// <summary>
        /// 起動時案内文
        /// </summary>
        [SerializeField]
        GameObject Text;

        /// <summary>
        /// 操作用オブジェクト一覧
        /// </summary>
        List<GameObject> ObjList;

        /// <summary>
        /// 操作用オブジェクト位置一覧
        /// </summary>
        List<Vector3> PosList;

        /// <summary>
        /// 操作用オブジェクト角度一覧
        /// </summary>
        List<Vector3> AngList;

        void Start()
        {
            ObjList = new List<GameObject>();
            PosList = new List<Vector3>();
            AngList = new List<Vector3>();

            // 初期配置保持
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                ObjList.Add(child.gameObject);
                PosList.Add(child.localPosition);
                AngList.Add(child.localEulerAngles);
            }

            foreach (var obj in ObjList)
            {
                obj.transform.parent = null;
            }
        }

        void Update()
        {
            if ((GrabPinch.GetState(SteamVR_Input_Sources.LeftHand) && GrabGrip.GetState(SteamVR_Input_Sources.LeftHand)) &&
                (GrabPinch.GetState(SteamVR_Input_Sources.RightHand) && GrabGrip.GetState(SteamVR_Input_Sources.RightHand)))
            {
                // 初期配置適用
                for (int i = 0; i < ObjList.Count; i++)
                {
                    ObjList[i].transform.parent = transform;
                    ObjList[i].transform.localPosition = PosList[i];
                    ObjList[i].transform.localEulerAngles = AngList[i];
                    ObjList[i].transform.parent = null;
                }

                // 最初の一回だけ意味あり
                Camera.transform.parent = null;
                Text.SetActive(false);
            }
        }
    }
}
