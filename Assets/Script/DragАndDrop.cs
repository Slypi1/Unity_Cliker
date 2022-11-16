using UnityEngine;
using UnityEngine.EventSystems;

public class DragАndDrop : MonoBehaviour,IBeginDragHandler,IDragHandler, IDropHandler, IEndDragHandler
{
    [SerializeField] private GameObject _nextGameObject;

    private SpriteRenderer _thicSpriteRenderer;
    private Vector3 _checkPoint;
    private CanvasGroup _canvasGroupSprite;

    private bool _isSpawn = false;

    public static event OnSpawn Spawn;
    public delegate void OnSpawn(bool spawn);

    private void Awake()
    {
        _thicSpriteRenderer = GetComponent<SpriteRenderer>();
        _canvasGroupSprite = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _checkPoint = transform.position;
        _canvasGroupSprite.blocksRaycasts = false;      
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position += (Vector3)eventData.delta * Time.deltaTime;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
          
            if (_thicSpriteRenderer.sprite == eventData.pointerDrag.GetComponent<SpriteRenderer>().sprite && _canvasGroupSprite.blocksRaycasts == true)
            {
                eventData.pointerDrag.GetComponent<Transform>().position = transform.position;
                Destroy(eventData.pointerDrag);
                Destroy(gameObject);
                Instantiate(_nextGameObject, transform.position, Quaternion.identity);
                _isSpawn = true;
                Spawn(_isSpawn);
            }
            else eventData.pointerDrag.GetComponent<Transform>().position = _checkPoint;                                 
        }      
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroupSprite.blocksRaycasts = true;
    } 
}
