using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int Ammo;
    public int HP;
    private Item[] savedItems;
    private GameObject[] savedObjects;
    private static DataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            savedItems = new Item[1];
            savedObjects = new GameObject[1];
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SaveItem(int index, Item item)
    {
        if (item != null)
        {
            savedItems[index] = item;
            // ���������� ���������� �������� � ����� ������� ���������� ������
        }
    }

    public Item GetSavedItem(int index)
    {
        return savedItems[index];
        // ���������� ��������� ������������ �������� �� ����� ������� ���������� ������
    }

    public void SaveObject(int index, GameObject obj)
    {
        if (obj != null)
        {
            savedObjects[index] = obj;
            // ���������� ���������� �������� ������� � ����� ������� ���������� ������
        }
    }

    public GameObject GetSavedObject(int index)
    {
        return savedObjects[index];
        // ���������� ��������� ������������ �������� ������� �� ����� ������� ���������� ������
    }
}