using UnityEngine;

public class UIPanelController : MonoBehaviour
{
    [Header("Panel Settings")]
    [SerializeField] private string menuCanvasName = "ClueMenu";
    
    [Tooltip("Menüyü açıp kapatmak için kullanılacak tuş")]
    [SerializeField] private KeyCode toggleKey = KeyCode.Tab;

    void Start()
    {
        if (CanvasManager.Instance != null)
        {
            GameObject canvasObj = transform.Find(menuCanvasName)?.gameObject ?? GameObject.Find(menuCanvasName);

            if (canvasObj != null)
            {
                CanvasManager.Instance.RegisterCanvas(menuCanvasName, canvasObj);
            }
            else
            {
                Debug.LogWarning($"UIPanelController: '{menuCanvasName}' bulunamadı!");
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if (CanvasManager.Instance == null) return;

            var activeCanvas = CanvasManager.Instance.CurrentActiveCanvas;

            if (activeCanvas != null && activeCanvas.name == menuCanvasName)
            {
                CanvasManager.Instance.CloseCanvas(menuCanvasName);
            }
            else
            {
                CanvasManager.Instance.OpenCanvas(menuCanvasName);
            }
        }
    }
}
