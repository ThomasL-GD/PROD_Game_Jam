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
    [SerializeField] float m_pickupReach = 2;

    static public bool m_canInteract = false;

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

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;
        Physics.Raycast(transform.position, fwd, out hit, m_pickupReach);

        if (hit.collider != null && hit.collider.CompareTag("Bonus"))
        {
            m_canInteract = true;
            if (Input.GetButtonDown("Pickup"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            m_canInteract = false;
        }
    }


    //if (Physics.Raycast (transform.position, fwd, hit, Reach) && hit.transform.tag == "Dynamic")
}
