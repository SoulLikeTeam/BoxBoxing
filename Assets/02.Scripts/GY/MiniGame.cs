using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    int i;
    private void Update()
    {
        Game();
    }
    public void Game()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }
        //yield return new WaitForSeconds(0.1f);
    }
    public void OnClick()
    {

    }
}