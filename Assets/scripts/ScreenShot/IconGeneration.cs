//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public class IconGeneration : MonoBehaviour
//{
//    public List<GameObject> sceneObjects;
//    public List<InventoryItemData> dataObjects;
//    public string pathFolder = "Icons";
//    private new Camera camera;

//    private void Awake()
//    {
//        camera = GetComponent<Camera>();
//    }

//    [ContextMenu("Screenshot")]
//    private void ProcessScreenshots()
//    {
//        StartCoroutine(Screenshot());
//    }

//    private IEnumerator Screenshot()
//    {
//        for (int i = 0; i < sceneObjects.Count; i++)
//        {
//            GameObject obj = sceneObjects[i];
//            InventoryItemData data = dataObjects[i];

//            obj.gameObject.SetActive(true);

//            yield return null;

//            TakeScreenshot($"{Application.dataPath}/{pathFolder}/{data.id}_Icon.png");
//            yield return null;
//            obj.gameObject.SetActive(false);
//            Sprite s = AssetDatabase.LoadAssetAtPath<Sprite>($"Assets/{pathFolder}/{data.id}_Icon.png");
//            if (s != null)
//            {


//                data.icon = s;
//                EditorUtility.SetDirty(data);
//            }

//            yield return null;
//        }
//    }

//    Texture2D TakeScreenshot(string fullPath)
//    {
//        if (camera == null)
//        {
//            Debug.LogError("Camera component not found.");
//            return null;
//            //camera = GetComponent<Camera>();
//        }
//        RenderTexture rt = new RenderTexture(256, 256, 24);
//        camera.targetTexture = rt;
//        Texture2D screenShot = new Texture2D(256, 256, TextureFormat.RGBA32, false);
//        camera.Render();
//        RenderTexture.active = rt;
//        screenShot.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
//        camera.targetTexture = null;
//        RenderTexture.active = null;

//        if (Application.isEditor)
//        {
//            DestroyImmediate(rt);
//        }
//        else
//        {
//            Destroy(rt);
//        }

//        byte[] bytes = screenShot.EncodeToPNG();
//        System.IO.File.WriteAllBytes(fullPath, bytes);
//#if UNITY_EDITOR
//        AssetDatabase.Refresh();
//#endif

//        return screenShot;
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{
    Camera cam;
    public string pathFolder;


    public List<GameObject> sceneObjects;
    public List<InventoryItemData> dataObjects;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    [ContextMenu("Screenshot")]
    private void ProcessScreenshots()
    {
        StartCoroutine(Screenshot());
    }

    private IEnumerator Screenshot()
    {
        for (int i = 0; i < sceneObjects.Count; i++)
        {
            GameObject obj = sceneObjects[i];
            InventoryItemData data = dataObjects[i];

            obj.gameObject.SetActive(true);
            yield return null;

            TakeShot($"{Application.dataPath}/{pathFolder}/{data.id}_Icon.png");

            yield return null;
            obj.gameObject.SetActive(false);

            Sprite s = AssetDatabase.LoadAssetAtPath<Sprite>($"Assets/{pathFolder}/{data.id}_Icon.png");
            if (s != null)
            {
                data.icon = s;
                EditorUtility.SetDirty(data);
            }
            yield return null;
        }
    }
     void TakeShot(string fullPath)
    {
        if (cam == null)
        {
            cam = GetComponent<Camera>();
        }

        RenderTexture rt = new RenderTexture(256, 256, 24);
        cam.targetTexture = rt;
        Texture2D screenShot = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        cam.Render();
        RenderTexture.active = rt;

        screenShot.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        cam.targetTexture = null;
        RenderTexture.active = null;

        if (Application.isEditor)
        {
            DestroyImmediate(rt);
        }
        else
        {
            Destroy(rt);
        }

        byte[] bytes = screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes(fullPath, bytes);

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif

    }
}
















