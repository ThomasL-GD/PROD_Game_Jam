using UnityEngine;

public class CameraFirstPersonLook : MonoBehaviour
{
    [SerializeField]
    GameObject m_player = null;
    Transform m_playerPosition;
    Vector2 m_currentMouseLook;
    Vector2 m_appliedMouseDelta;
    [SerializeField] float m_sensitivity = 1;
    [SerializeField] float m_smoothing = 2;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        m_playerPosition = m_player.GetComponent<Transform>();
    }

    void Update()
    {
        // Get smooth mouse look.
        Vector2 smoothMouseDelta = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * m_sensitivity * m_smoothing);
        m_appliedMouseDelta = Vector2.Lerp(m_appliedMouseDelta, smoothMouseDelta, 1 / m_smoothing);
        m_currentMouseLook += m_appliedMouseDelta;
        m_currentMouseLook.y = Mathf.Clamp(m_currentMouseLook.y, -90, 90);

        // Rotate camera and controller.
        transform.localRotation = Quaternion.AngleAxis(-m_currentMouseLook.y, Vector3.right);
        m_playerPosition.localRotation = Quaternion.AngleAxis(m_currentMouseLook.x, Vector3.up);
    }
}
