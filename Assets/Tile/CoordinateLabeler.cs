using UnityEngine;
using TMPro;


[ExecuteAlways]
[RequireComponent(typeof (TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color _defaultColor = Color.white;
    [SerializeField] Color _blockedColor= Color.grey;


    private TextMeshPro _label;
    private Vector2Int _coordinates = new Vector2Int();
    private WayPoint _waypoint;


    void Awake()
    {
        _label = GetComponent<TextMeshPro>();
        _label.enabled = false;
        _waypoint = GetComponentInParent<WayPoint>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            _label.enabled = true;
        }
        
        SetLabelColor();
        ToggleLabel();
    }

    private void SetLabelColor()
    {
        if (_waypoint.IsPlaceable)
        {
            _label.color = _defaultColor;
        }
        else
        {
            _label.color = _blockedColor;
        }
    }

    private void ToggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _label.enabled = !_label.IsActive();
        }
    }

    private void DisplayCoordinates()
    {
        _coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        _coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        _label.text = $"{_coordinates.x},{_coordinates.y}";
    }

    private void UpdateObjectName()
    {
        transform.parent.name = _coordinates.ToString();
    }
}
