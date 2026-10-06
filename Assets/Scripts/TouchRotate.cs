using UnityEngine;
using UnityEngine.InputSystem;

public class TouchRotate : MonoBehaviour
{
    public float autoRotationSpeed = 20f;
    public float touchRotationSpeed = 0.5f;

    public float zoomSpeed = 0.005f;
    public float minScale = 0.3f;
    public float maxScale = 2f;

    void Update()
    {
        bool isInteracting = false;

        // Mouse rotation
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            isInteracting = true;

            Vector2 delta = Mouse.current.delta.ReadValue();

            transform.Rotate(
                -delta.y * touchRotationSpeed,
                -delta.x * touchRotationSpeed,
                0
            );
        }

        // Touch rotation
        if (Touchscreen.current != null)
        {
            var touch = Touchscreen.current.primaryTouch;

            if (touch.press.isPressed)
            {
                isInteracting = true;

                Vector2 delta = touch.delta.ReadValue();

                transform.Rotate(
                    -delta.y * touchRotationSpeed,
                    -delta.x * touchRotationSpeed,
                    0
                );
            }

            // Pinch zoom
            if (Touchscreen.current.touches.Count >= 2)
            {
                var touch0 = Touchscreen.current.touches[0];
                var touch1 = Touchscreen.current.touches[1];

                if (touch0.press.isPressed &&
                    touch1.press.isPressed)
                {
                    isInteracting = true;

                    Vector2 currentPos0 =
                        touch0.position.ReadValue();

                    Vector2 currentPos1 =
                        touch1.position.ReadValue();

                    Vector2 previousPos0 =
                        currentPos0 - touch0.delta.ReadValue();

                    Vector2 previousPos1 =
                        currentPos1 - touch1.delta.ReadValue();

                    float currentDistance =
                        Vector2.Distance(
                            currentPos0,
                            currentPos1
                        );

                    float previousDistance =
                        Vector2.Distance(
                            previousPos0,
                            previousPos1
                        );

                    float difference =
                        currentDistance - previousDistance;

                    Vector3 newScale =
                        transform.localScale +
                        Vector3.one *
                        difference *
                        zoomSpeed;

                    float scale = Mathf.Clamp(
                        newScale.x,
                        minScale,
                        maxScale
                    );

                    transform.localScale =
                        Vector3.one * scale;
                }
            }
        }

        // Auto rotation
        if (!isInteracting)
        {
            transform.Rotate(
                0,
                autoRotationSpeed * Time.deltaTime,
                0
            );
        }
    }
}