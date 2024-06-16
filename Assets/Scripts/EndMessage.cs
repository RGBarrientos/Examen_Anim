using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMessage : MonoBehaviour
{
    [SerializeField]
    private TMP_Text endGameText; 

    [SerializeField]
    private string targetTag = "Key"; // Asegúrate de que esto está configurado a "key"

    [SerializeField]
    private float delayBeforeChangeScene = 5f; // Tiempo de espera antes de cambiar de escena

    private void Start()
    {
        // Asegurarse de que el texto esté oculto al inicio
        if (endGameText != null)
        {
            endGameText.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("El campo 'endGameText' no está asignado.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionamos tiene el tag correcto
        if (collision.gameObject.CompareTag(targetTag))
        {
            ShowEndGameMessage();
            Debug.Log("|Felicidades! \\ Fin del juego");
        }
    }

    private void ShowEndGameMessage()
    {
        if (endGameText != null)
        {
            endGameText.gameObject.SetActive(true);
            endGameText.text = "Juego Terminado";
            Invoke("ChangeScene", delayBeforeChangeScene);
        }
    }

    private void ChangeScene()
    {
        // Cambia a la escena "Menu"
        SceneManager.LoadScene("Menu");
    }
}
