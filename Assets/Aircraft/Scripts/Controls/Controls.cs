using UnityEngine;

public class Controls : MonoBehaviour
{
    public float Yaw { get; private set; } = 0f; // –ыскание
    public float Roll { get; private set; } = 0f; //  рен
    public float Pitch { get; private set; } = 0f; // “ангаж
    public float Pull { get; private set; } = 0f; // “€га
    public bool GearsOut { get; private set; } = true;// Ўасси
    public bool Breaks { get; private set; } = false;// “ормоза

    private void Update()
    {
        // ”правление рысканием на клавиши Q и E
        Yaw = 0; 
        if (Input.GetKey(KeyCode.Q))
            Yaw += 1;
        if (Input.GetKey(KeyCode.E))
            Yaw -= 1;

        // ”правление тангажем на клавиши W и S
        Pitch = Input.GetAxis("Vertical");

        // ”правление креном на клавиши A и D
        Roll = Input.GetAxis("Horizontal");

        // ”правление т€гой на LeftShift и LeftCtrl
        if (Input.GetKey(KeyCode.LeftShift)) 
            Pull = Mathf.Clamp(Pull + Time.deltaTime, 0f, 1f);
        if (Input.GetKeyDown(KeyCode.LeftCommand))
            Pull = Mathf.Clamp(Pull - Time.deltaTime, 0f, 1f);

        // ”борка и выпуск шасси на клавише G
        if (Input.GetKeyDown(KeyCode.G))
            GearsOut = !GearsOut;

        // “орможение включаетс€ при нулевой т€ге и зажатой клавише уменьшени€ т€ги LeftCtrl
        if (Input.GetKey(KeyCode.LeftCommand) && Pull == 0f)
            Breaks = true;
        else
            Breaks = false;
    }
}
