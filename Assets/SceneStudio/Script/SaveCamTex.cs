using System;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace SceneStudio
{
    /// <summary>
    /// カメラのレンダーテクスチャを画像保存
    /// </summary>
    public class SaveCamTex : SteamVR_Clench
    {
        /// <summary>
        /// カメラのレンダーテクスチャ
        /// </summary>
        [SerializeField]
        RenderTexture CamTex;

        /// <summary>
        /// シャッター音
        /// </summary>
        [SerializeField]
        AudioSource SE;

        /// <summary>
        /// 保存した画像を貼る元のオブジェクト
        /// </summary>
        [SerializeField]
        GameObject Photo;

        /// <summary>
        /// 保存先(Application.dataPath相対)
        /// </summary>
        [SerializeField]
        string Path;

        /// <summary>
        /// ガンマ補正
        /// </summary>
        [SerializeField]
        float Gamma;

        void Start()
        {
            Init();
        }

        void Update()
        {
            if (IsClench())
            {
                // 生成
                Texture2D tex = new Texture2D(CamTex.width, CamTex.height, TextureFormat.RGB24, false);
                RenderTexture.active = CamTex;
                tex.ReadPixels(new Rect(0, 0, CamTex.width, CamTex.height), 0, 0);
                tex.Apply();

                // 保存
                byte[] bytes = tex.EncodeToPNG();
                string path = Application.dataPath + "\\" + Path;
                path += DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2");
                path += DateTime.Now.Hour.ToString("D2") + DateTime.Now.Minute.ToString("D2") + DateTime.Now.Second.ToString("D2");
                path += ".png";
                File.WriteAllBytes(path, bytes);

                // 表示
                var photo = Instantiate(Photo);
                photo.transform.position = Photo.transform.position;
                photo.transform.rotation = Photo.transform.rotation;
                photo.transform.localScale = Photo.transform.lossyScale;
                photo.SetActive(true);
                var display = photo.transform.Find("Display");
                if (display != null)
                {
                    display.gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", tex);
                }

                // 無いと撮れたか分からないので意外と必要
                SE.Play();
            }
        }
    }
}
