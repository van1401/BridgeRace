using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : UICanvas
{
    public Text score;

    public void MainMenuButton()
    {
        UIManager.Instance.OpenUI<MianMenu>();
        Close(0);
    }
}
