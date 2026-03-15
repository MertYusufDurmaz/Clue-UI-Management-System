using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ClueListUI : MonoBehaviour
{
    public static ClueListUI Instance { get; private set; }

    [Header("References")]
    public GameObject clueItemPrefab;
    public Transform gridLayoutGroup;

    private List<string> foundClues = new List<string>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddClue(string clueText)
    {
        if (!foundClues.Contains(clueText))
        {
            foundClues.Add(clueText);
            SpawnClueObject(clueText);
        }
    }

    private void SpawnClueObject(string text)
    {
        if (clueItemPrefab != null && gridLayoutGroup != null)
        {
            GameObject newClueItem = Instantiate(clueItemPrefab, gridLayoutGroup);

            TextMeshProUGUI textComponent = newClueItem.GetComponentInChildren<TextMeshProUGUI>();

            if (textComponent == null)
            {
                textComponent = newClueItem.GetComponent<TextMeshProUGUI>();
            }

            if (textComponent != null)
            {
                textComponent.text = text;
            }

            newClueItem.SetActive(true);
        }
    }

    // --- SAVE SİSTEMİ İÇİN KULLANILACAK METOTLAR ---
    
    public List<string> GetAllClues()
    {
        return foundClues;
    }

    public void LoadClues(List<string> loadedTexts)
    {
        // 1. Ekranda olanları temizle
        foreach (Transform child in gridLayoutGroup)
        {
            Destroy(child.gameObject);
        }
        foundClues.Clear();

        // 2. Kayıtlı olanları oluştur
        if (loadedTexts != null)
        {
            foreach (string txt in loadedTexts)
            {
                foundClues.Add(txt); 
                SpawnClueObject(txt); 
            }
        }
    }
}
