using System;
using System.Collections.Generic;
using UnityEngine;

public class TestPanel : MonoBehaviour
{
    [SerializeField] private TestButton[] _testButtons;
    
    private bool Click = false;
    private Ray ray;
    RaycastHit hitInfo;
    public Camera camera;
    
    private List<int> _chars = new List<int>
    {
        1,
     
    };

    private int currentPage;
    
    private void Start()
    {
        currentPage = 0;
        Refresh();
    }

    public void Refresh()
    {
        for (var i = 0; i < _testButtons.Length; i++)
        {
            var charIndex = i + currentPage;

            if (charIndex < _chars.Count)
            {
                _testButtons[i].gameObject.SetActive(true);
                _testButtons[i].SetImage(_chars[i + currentPage], this);   
            }
            else
            {
                _testButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void CreateChar(int charId)
    {
        if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("hit !!");
 
                ray = camera.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out hitInfo, 100f))
                {
                    if (hitInfo.collider.tag == "Floor")
                    {
                        Instantiate(Resources.Load("UnitPrefab/" + charId), hitInfo.point,
                            Quaternion.Euler(0, 90, 0));
                        TestButton.chack = false;
                    }
                }
            }
        
    }

    public void OnNextButtonClick()
    {
        currentPage += _testButtons.Length;

        if (currentPage > _chars.Count)
        {
            currentPage = 0;
        }
        
        Refresh();
    }
}
