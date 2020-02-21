using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDevice
{
    private static InputDevice Instance;
    private static InputDeviceType Device;
    private InputDevice()
    {
        Device = InputDeviceType.KeyboardAndMouse;
    }

    public static InputDevice GetInstance()
    {
        if (Instance == null)
            return new InputDevice();
        else
        {
            Instance = new InputDevice();
            return Instance;
        }
    }

    enum InputDeviceType
    {
        XBoxController,
        KeyboardAndMouse
    }

    bool IsIdle()
    {
        switch (Device)
        {
            case InputDeviceType.XBoxController:// TODO: add xbox controller
                return !Input.GetKey("") && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)
                    && !Input.GetKeyDown(KeyCode.Mouse0);

            case InputDeviceType.KeyboardAndMouse:
                    return !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)
                    && !Input.GetKeyDown(KeyCode.Mouse0);
                break;
        }
        return false;
    }

    bool IsRun()
    {
        switch (Device)
        {
            case InputDeviceType.XBoxController:
                break;

            case InputDeviceType.KeyboardAndMouse:
                break;
        }
        return false;
    }
}
