using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AddPostProcessLayer : MonoBehaviour
{
    void Start()
    {
        GameObject mainCamera = transform.parent.gameObject;
        mainCamera.tag = "MainCamera";

        PostProcessLayer postProcessLayer = mainCamera.AddComponent<PostProcessLayer>();
        postProcessLayer.volumeLayer = LayerMask.GetMask("Post Processing");

        PostProcessVolume postProcessVolume = FindObjectOfType<PostProcessVolume>();

        if (!postProcessVolume)
            postProcessVolume = new GameObject("PostProcessVolume").AddComponent<PostProcessVolume>();

        postProcessVolume.profile = AssetDatabase.LoadAssetAtPath<PostProcessProfile>("Assets/YourProfile.asset");
        postProcessVolume.isGlobal = true;
        postProcessVolume.gameObject.layer = LayerMask.NameToLayer("Post Processing");


    }
}
