using UnityEngine;

public class UIPanelController : MonoBehaviour
{
    [Header("Canvas Adlarý")]
    [SerializeField] private string menuCanvasName = "ClueMenu";

    [Header("Player Kontrol Referanslarý (KULLANILMIYOR)")]
    public MovementController playerMovement;
    public MouseLook mouseLook;
    public InspectionHandler inspectorHandler;
    public GameObject crosshairUI;

    // --- DÜZELTME: 'Awake' metodunun adýný 'Start' olarak deðiþtirdik ---
    void Start()
    {
        if (CanvasManager.Instance != null)
        {
            GameObject canvasObj = gameObject.transform.Find(menuCanvasName)?.gameObject ?? GameObject.Find(menuCanvasName);

            if (canvasObj != null)
            {
                CanvasManager.Instance.RegisterCanvas(menuCanvasName, canvasObj);
                Debug.Log("ClueMenu kaydedildi: " + canvasObj.name);
            }
            else
            {
                Debug.LogError("Start'ta " + menuCanvasName + " bulunamadý!");
            }
        }
        else
        {
            Debug.LogError("CanvasManager.Instance null!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (CanvasManager.Instance == null) return;

            if (CanvasManager.Instance.CurrentActiveCanvas != null &&
                CanvasManager.Instance.CurrentActiveCanvas.name == menuCanvasName)
            {
                CanvasManager.Instance.CloseCanvas(menuCanvasName);
                Debug.Log("ClueMenu kapatýldý.");
            }
            else
            {
                CanvasManager.Instance.OpenCanvas(menuCanvasName);
                Debug.Log("ClueMenu açýldý.");
            }
        }
    }
}