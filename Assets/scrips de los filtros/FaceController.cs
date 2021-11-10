using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(ARFaceManager))]
public class FaceController : MonoBehaviour
{
    [SerializeField]
    private Button faceTrackingToggle;

    [SerializeField]
    private Button swapFacesToggle;

    private ARFaceManager arFaceManager;
    private ARFace arface;

    private bool faceTrackingOn = true;

    private int swapCounter = 0;

    [SerializeField]
    public GameObject[] Models;

    public Text nombrePanel;

    public Button BUTTOM0;
    public Button buttom1;
    public Button buttom2;
    public Button buttom3;
    public static int panelId;

    private void Start()
    {
	    arface = GetComponent<ARFace>();
	    arFaceManager = GetComponent<ARFaceManager>();
	    arFaceManager.facePrefab = Models[0];


    }
    public void ButtomSwapFaces()
    {
        
        if(buttom1 == true){ swapCounter = 0; SwapFaces(); }
    }

    public void ButtomSwapFaces1()
    {

        if (buttom1 == true) { swapCounter = 1; SwapFaces(); }
    }

    public void ButtomSwapFaces2()
    {

        if (buttom1 == true) { swapCounter = 2; SwapFaces(); }
    }

    //void Awake()
    //{
    //    arFaceManager = GetComponent<ARFaceManager>();

    //    BUTTOM0.onClick.AddListener(ToggleTrackingFaces);        //buttom1.onClick.AddListener(SwapFaces);
    //   // buttom2.onClick.AddListener(SwapFaces);


    //    arFaceManager.facePrefab = Models[0];
    //}

	

    public void SwapFaces()
    {
        // Debug.Log("PanelID" + panelId.ToString());
        //foreach (ARFaceManager face in arface.)
        //{
        // face.GetComponent<MeshRenderer>().material = Models[(panelId-1)].Ga;
        //}
        //swapFacesToggle.GetComponentInChildren<Text>().text = $"Face Material ({materials[0].Name})";
        // arFaceManager.enabled = false;
        //arFaceManager.enabled = true;

        arFaceManager.facePrefab = Models[swapCounter];
        CancelButton();
    }

    public void CancelButton()
    {
        StartCoroutine(Animate());
    }


    private IEnumerator Animate()
    {
        arFaceManager.enabled = false;
        yield return new WaitForSeconds(0.1f);
        //gameObject.SetActive(false);
        arFaceManager.enabled = true;
        
    }



void ToggleTrackingFaces()
    {
        faceTrackingOn = !faceTrackingOn;

        foreach (ARFace face in arFaceManager.trackables)
        {
            face.enabled = faceTrackingOn;
        }

        faceTrackingToggle.GetComponentInChildren<Text>().text = $"Face Tracking {(arFaceManager.enabled ? "Off" : "On")}";
    }

}

[System.Serializable]
public class FaceMaterial
{
    public Material Material;

    public string Name;
}