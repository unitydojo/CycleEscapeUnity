using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    [SerializeField] private GameObject correctAnswerCircle;
    [SerializeField] private float resetPositionSpeed = 1.5f;
    [SerializeField] private Sprite correctStateSprite;
    [SerializeField] private DocumentsSceneBrain _sceneBrain;
    [SerializeField] private int documentID;
    
    private Camera _camera;
    private SpriteRenderer _renderer;
    private Vector3 _clickOffset;
    private bool _movedToCorrectPosition = false;
    private Vector3 _initialPosition;
    private bool _resetToInitialPosition = false;
    private bool _isInCorrectArea = false;
    
    public bool IsInCorrectPosition()
    {
        return _movedToCorrectPosition;
    }
    
    private void Awake()
    {
        _camera = Camera.main;
        _initialPosition = transform.position;
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_resetToInitialPosition == false) { return; }
        _resetToInitialPosition = transform.position != _initialPosition;
        transform.position = Vector3.MoveTowards(transform.position,_initialPosition, resetPositionSpeed);
    }

    private void OnMouseDown()
    {
        if (_movedToCorrectPosition) { return; }
        _clickOffset = transform.position - GetMousePos();
    }

    private void OnMouseDrag()
    {
        if (_movedToCorrectPosition) { return; }
        transform.position = GetMousePos() + _clickOffset;
    }

    private void OnMouseUp()
    {
        if (_movedToCorrectPosition) { return; }
        if (_isInCorrectArea)
        {
            _movedToCorrectPosition = true;
            _renderer.sprite = correctStateSprite;
            transform.position = correctAnswerCircle.transform.position; //center it
            _sceneBrain.DocumentTimeOrderFound(documentID);
        }
        else
        {
            _resetToInitialPosition = true;
            _sceneBrain.PlayErrorSound();
        }
    }

    private Vector3 GetMousePos()
    {
        var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == correctAnswerCircle)
        {
            _isInCorrectArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == correctAnswerCircle)
        {
            _isInCorrectArea = false;
        }
    }
}

