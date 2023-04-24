using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    private GameObject _clickCheck;

    private void Awake()
    {
        _clickCheck = transform.GetChild(0).gameObject;
    }

    //Cambia el objeto del efecto de acuerdo a la posici�n que se hizo clic
    public void DoEffect(Vector3 effectPosition)
    {
        _clickCheck.transform.position = effectPosition;
    }
}
