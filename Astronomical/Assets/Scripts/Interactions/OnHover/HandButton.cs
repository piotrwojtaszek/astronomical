using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class HandButton : XRBaseInteractable
{
    public UnityEvent OnPress = null;
    private float m_yMax = 0.0f;
    private float m_yMin = 0.0f;
    private bool m_previousPress = false;

    private float m_previousHandHeight = 0.0f;
    private XRBaseInteractor m_hoverInteractor = null;
    protected override void Awake()
    {
        base.Awake();
        onHoverEntered.AddListener(StartPress);
        onHoverExited.AddListener(EndPress);
    }

    protected override void OnDestroy()
    {
        onHoverEntered.RemoveListener(StartPress);
        onHoverExited.RemoveListener(EndPress);
    }

    private void StartPress(XRBaseInteractor interactor)
    {
        m_hoverInteractor = interactor;
        m_previousHandHeight = GetLocalYPosition(m_hoverInteractor.transform.position);
    }

    private void EndPress(XRBaseInteractor interactor)
    {
        m_hoverInteractor = null;
        m_previousHandHeight = 0.0f;

        m_previousPress = false;
        SetLocalYPosition(m_yMax);
    }

    private void Start()
    {
        SetMinMax();
    }

    private void SetMinMax()
    {
        Collider collider = GetComponent<Collider>();
        m_yMin = transform.localPosition.y - (collider.bounds.size.y * 0.5f);
        m_yMax = transform.localPosition.y;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (m_hoverInteractor)
        {
            float newHandHeight = GetLocalYPosition(m_hoverInteractor.transform.position);
            float handDiffrence = m_previousHandHeight - newHandHeight;
            m_previousHandHeight = newHandHeight;

            float newPosition = transform.localPosition.y - handDiffrence;
            SetLocalYPosition(newPosition);

            CheckPress();
        }
    }

    private float GetLocalYPosition(Vector3 position)
    {
        Vector3 localPosition = transform.root.InverseTransformPoint(position);

        return localPosition.y;
    }

    private void SetLocalYPosition(float position)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = Mathf.Clamp(position, m_yMin, m_yMax);
        transform.localPosition = newPosition;
    }

    private void CheckPress()
    {
        bool inPosition = InPosition();

        if (inPosition && inPosition != m_previousPress)
        {
            OnPress?.Invoke();
        }

        m_previousPress = inPosition;
    }

    private bool InPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y, m_yMin, m_yMin + 0.01f);

        return transform.localPosition.y == inRange;
    }
}
