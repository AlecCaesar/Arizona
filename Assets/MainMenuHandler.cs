using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{

   public void startGame(){
    SceneManager.LoadScene("GamePlay");
   }

   public void stopGame(){
      Application.Quit();
   } 


}
