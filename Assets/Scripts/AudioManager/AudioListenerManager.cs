using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioListenerManager : MonoBehaviour
{
    private void Awake()
    {
		AudioListener[] listeners = FindObjectsOfType<AudioListener>();
		if (listeners.Length > 1) // Si hay más de uno, destruir este
		{
			Destroy(gameObject);
		}
		else // Si es el único, asegurarse de que no se destruya al cambiar de escena
		{
			DontDestroyOnLoad(gameObject);
		}
	}

    void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		GameObject mainCamera = GameObject.Find("Main Camera");

		if (mainCamera != null)
		{
			Debug.Log("Se encontró la Main Camera.");
		}
		else
		{
			Debug.Log("No se encontró la Main Camera.");
		}
		gameObject.transform.position = mainCamera.transform.position;
        gameObject.transform.parent = mainCamera.transform;
    }
}
