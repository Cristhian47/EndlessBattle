using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f; // velocidad de movimiento del enemigo
    [SerializeField] private Transform _playerTransform; // transform del jugador
    private Rigidbody _rb; // rigidbody del enemigo

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Calcular la direcci�n hacia el jugador
        Vector3 direction = _playerTransform.position - transform.position;
        direction.Normalize();

        // Mover el enemigo en direcci�n al jugador
        _rb.MovePosition(transform.position + direction * _speed * Time.fixedDeltaTime);

        // Obtener la rotaci�n necesaria para mirar hacia el jugador en el eje Z
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(0, 0, 0f), Vector3.forward);

        // Asignar la rotaci�n del enemigo
        transform.rotation = lookRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AttackArea"))
        {
            gameObject.SetActive(false);
        }
    }
}
