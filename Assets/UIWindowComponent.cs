using UnityEngine;

public class UIWindowComponent : MonoBehaviour
{
   public void OpenWindow(){
        GetComponent<Canvas>().enabled = true;

   }

   public void CloseWindow(){
        GetComponent<Canvas>().enabled = false;
   }
}
