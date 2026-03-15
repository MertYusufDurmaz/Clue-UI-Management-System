using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ClueListUI : MonoBehaviour
{
    public static ClueListUI Instance { get; private set; }

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

    // --- YENÝ EKLENEN: SaveManager ile Baðlantý ---
    void Start()
    {
        if (GameSaveManager.Instance != null)
        {
            GameSaveManager.Instance.clueListUI = this;
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

    // Kod tekrarýný önlemek için UI oluþturmayý ayrý metoda aldým
    private void SpawnClueObject(string text)
    {
        if (clueItemPrefab != null && gridLayoutGroup != null)
        {
            GameObject newClueItem = Instantiate(clueItemPrefab, gridLayoutGroup);

            // Senin kodundaki gibi GetComponentInChildren kullanýyoruz
            TextMeshProUGUI textComponent = newClueItem.GetComponentInChildren<TextMeshProUGUI>();

            if (textComponent != null)
            {
                textComponent.text = text;
            }
            else
            {
                // Eðer prefabýn kendisinde varsa diye ikinci bir kontrol
                textComponent = newClueItem.GetComponent<TextMeshProUGUI>();
                if (textComponent != null) textComponent.text = text;
            }

            newClueItem.SetActive(true);
        }
    }

    // --- SAVE SÝSTEMÝ ÝÇÝN GEREKLÝ YENÝ METODLAR ---

    // SaveManager kaydederken bu listeyi isteyecek
    public List<string> GetAllClues()
    {
        return foundClues;
    }

    // SaveManager yüklerken bu listeyi geri verecek
    public void LoadClues(List<string> loadedTexts)
    {
        // 1. Önce ekrandaki eski yazýlarý temizle
        foreach (Transform child in gridLayoutGroup)
        {
            Destroy(child.gameObject);
        }

        // Listeyi sýfýrla
        foundClues.Clear();

        // 2. Kayýtlý olanlarý tek tek ekle ve oluþtur
        if (loadedTexts != null)
        {
            foreach (string txt in loadedTexts)
            {
                foundClues.Add(txt); // Listeye ekle
                SpawnClueObject(txt); // Ekranda oluþtur
            }
        }
    }
}