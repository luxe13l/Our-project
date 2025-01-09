using UnityEngine;

public class StartGame : MonoBehaviour
{
   public static bool IsGameStarted = false;
   public GameObject Logo, PlayImage;
   
   public void PlayGame()
   {
    IsGameStarted = true;
    Logo.SetActive(false);
    PlayImage.SetActive(false);
   }












}
