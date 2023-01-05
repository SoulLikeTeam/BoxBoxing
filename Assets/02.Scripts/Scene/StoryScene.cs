using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StoryScene : BaseScene
{

    public void StorySkip()
    {
        Managers.Scene.LoadScene(Define.Scene.Menu);
    }

    public override void Clear()
    {
        
    }

}
