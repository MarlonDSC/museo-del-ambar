using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARTrackedImageManager))]

public class NewBehaviourScript : MonoBehaviour
{
	[SerializeField]
	private GameObject[]placeable;
	
	
	private Dictionary<string,GameObject> Spawnedprefabs= new Dictionary<string, GameObject>();
	private ARTrackedImageManager trakedImageManager;

	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		trakedImageManager= FindObjectOfType<ARTrackedImageManager>();
		
		foreach(GameObject prefab in placeable)
		{
			GameObject newPrefa= Instantiate(prefab,Vector3.zero,Quaternion.identity);
			newPrefa.name= prefab.name;
			Spawnedprefabs.Add(prefab.name,newPrefa);
		
		}
	}

	
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		trakedImageManager.trackedImagesChanged+= ImagecChanged;
	}
  
	// This function is called when the behaviour becomes disabled () or inactive.
	protected void OnDisable()
	{
		trakedImageManager.trackedImagesChanged-= ImagecChanged;
	}
  
	

	private void ImagecChanged(ARTrackedImagesChangedEventArgs eventArgs)
	{
		foreach(ARTrackedImage trakedImage in eventArgs.added){
			UpdateImage(trakedImage);
		
		}
		foreach(ARTrackedImage trakedImage in eventArgs.updated){
			UpdateImage(trakedImage);
		
		}
		foreach(ARTrackedImage trakedImage in eventArgs.removed){
			Spawnedprefabs[trakedImage.name].SetActive(false);
		
		}
				
	}
	
	
	private void UpdateImage(ARTrackedImage trackedImage){
		
		string name = trackedImage.referenceImage.name;
		Vector3 position= trackedImage.transform.position;
		
		GameObject prefab=Spawnedprefabs[name];
		prefab.transform.position=position;
		prefab.SetActive(true);
		
		foreach(GameObject go in Spawnedprefabs.Values){
			if(go.name!=name){
				//go.SetActive(false);
			}
		}
		
	}
  
  
}
