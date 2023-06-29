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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveItem(int index, Item item)
    {
        savedItems[index] = item;
        // ���������� ���������� �������� � ����� ������� ���������� ������
    }

    public Item GetSavedItem(int index)
    {
        return savedItems[index];
        // ���������� ��������� ������������ �������� �� ����� ������� ���������� ������
    }

    public void SaveObject(int index, GameObject obj)
    {
        savedObjects[index] = obj;
        // ���������� ���������� �������� ������� � ����� ������� ���������� ������
    }

    public GameObject GetSavedObject(int index)
    {
        return savedObjects[index];
        // ���������� ��������� ������������ �������� ������� �� ����� ������� ���������� ������
    }
}