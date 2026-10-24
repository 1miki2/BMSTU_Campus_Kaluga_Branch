using UnityEngine;
using UnityEngine.InputSystem;

public class Hide_floors : MonoBehaviour
{
    public GameObject[] floors;
    
    void Update()
    {
        if (Mouse.current == null) return;
        if (!Mouse.current.leftButton.wasPressedThisFrame) return;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            int index = System.Array.IndexOf(floors, hit.collider.gameObject);
            if (index < 0) return;
            for (int i = index + 1; i < floors.Length; i++)
            {
                if (floors[i] != null) floors[i].SetActive(false);
            }
        }
    }

    public void ShowAllFloors()
    {
        foreach (var f in floors)
        {
            if (f != null) f.SetActive(true);
        }
    }
}
