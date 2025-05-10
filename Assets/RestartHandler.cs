using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartHandler : MonoBehaviour
{
    public void startGame(){
    SceneManager.LoadScene("GamePlay");
   } 

   public void MainMenu(){
    SceneManager.LoadScene("Main Menu");
   }
}
