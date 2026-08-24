using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private List<CinemachineCamera> _cinemachineCameras = new List<CinemachineCamera>();
    [SerializeField] private KeyCode _switchKeyCode;

    private int _indexCamera = 0;

    private void Awake()
    {
        SetCamera(_indexCamera);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_switchKeyCode))
        {
            Switch();
        }
    }

    private void Switch()
    {
        _indexCamera++;

        if (_indexCamera >= _cinemachineCameras.Count) _indexCamera = 0;

        SetCamera(_indexCamera);
    }

    private void SetCamera(int index)
    {
        foreach (CinemachineCamera cam in _cinemachineCameras)
        {
            cam.enabled = false;
        }

        _cinemachineCameras[index].enabled = true;
    }
}
