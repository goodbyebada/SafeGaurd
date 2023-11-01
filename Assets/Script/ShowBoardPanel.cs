using UnityEngine;
using UnityEngine.UI;

public class ShowBoardPanel : MonoBehaviour { 

    public Canvas canvas;
    public GameObject panel1, panel2, panel3, panel4, panel5, teacherOffice;
    private GameObject[] panels =new GameObject[6];

    private void Awake()
    {

        SetPanelArray();

        for (int i = 0; i< panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
    }


   public void SetPanelArray()
    {
        panels[0] = panel1;
        panels[1] = panel2;
        panels[2] = panel3;
        panels[3] = panel4;
        panels[4] = panel5;
        panels[5] = teacherOffice;
    }
}