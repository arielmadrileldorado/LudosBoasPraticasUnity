using UnityEngine;

public class HolderManager : MonoBehaviour
{

    [SerializeField] private AudioClip _selectAduio;
    [SerializeField] private AudioClip _unselectAduio;
    [SerializeField] private Camera arCamera;

    AudioSource _audioSource;

    private Holdable _holdingItem;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;

        var touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {

            if (_holdingItem)
            {
                _audioSource.clip = _unselectAduio;
                if(_audioSource.clip != null) _audioSource.Play();
                _holdingItem.Drop();
                _holdingItem = null;
                return;
            }
            
            var ray = arCamera.ScreenPointToRay(touch.position);

            if (Physics.Raycast(ray, out var hitObject, 2f))
            {
                if (hitObject.transform.TryGetComponent(out Holdable holdItem))
                {
                    _audioSource.clip = _selectAduio;
                    if (_audioSource.clip != null) _audioSource.Play();
                    holdItem.Hold(arCamera.transform);
                    _holdingItem = holdItem;
                }
            }
        }
    }
}
