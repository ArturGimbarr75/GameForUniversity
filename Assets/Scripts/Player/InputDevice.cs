using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDevice
{
    private static InputDevice Instance;
    private static InputDeviceType Device;
    private InputDevice()
    {
        Device = InputDeviceType.XBoxController;
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

    public bool IsIdle()
    {
        switch (Device)
        {
            case InputDeviceType.XBoxController:
                return Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 /*&& !Input.GetButton("XboxRT")*/;

            case InputDeviceType.KeyboardAndMouse:
                return !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)
                && !Input.GetKeyDown(KeyCode.Mouse0);
        }
        return false;
    }

    public bool IsRun()
    {
        switch (Device)
        {
            case InputDeviceType.XBoxController:
                //return Input.GetAxis("Vertical") > 0 && Input.GetAxis("XboxLT") > 0;

            case InputDeviceType.KeyboardAndMouse:
                return Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift);
        }
        return false;
    }

    public bool IsWalkForward()
    {
        switch (Device)
        {
            case InputDeviceType.XBoxController:
                return Input.GetAxis("Vertical") > 0;

            case InputDeviceType.KeyboardAndMouse:
                return Input.GetKey(KeyCode.W);
        }
        return false;
    }

    public bool IsWalkBack()
    {
        switch (Device)
        {
            case InputDeviceType.XBoxController:
                return Input.GetAxis("Vertical") < 0;

            case InputDeviceType.KeyboardAndMouse:
                return Input.GetKey(KeyCode.S);
        }
        return false;
    }

    public bool IsWalkLeft()
    {
        switch (Device)
        {
            case InputDeviceType.XBoxController:
                return Input.GetAxis("Horizontal") < 0;

            case InputDeviceType.KeyboardAndMouse:
                return Input.GetKey(KeyCode.A);
        }
        return false;
    }

    public bool IsWalkRight()
    {
        switch (Device)
        {
            case InputDeviceType.XBoxController:
                return Input.GetAxis("Horizontal") > 0;

            case InputDeviceType.KeyboardAndMouse:
                return Input.GetKey(KeyCode.D);
        }
        return false;
    }

    public bool IsAttak()
    {
        switch (Device)
        {
            case InputDeviceType.XBoxController:
                //return Input.GetAxis("XboxRT") > 0;

            case InputDeviceType.KeyboardAndMouse:
                return Input.GetKeyDown(KeyCode.Mouse0);
        }
        return false;
    }

    public bool IsJump()
    {
        switch (Device)
        {
            case InputDeviceType.XBoxController:
                //return Input.GetAxis("XboxA") > 0;

            case InputDeviceType.KeyboardAndMouse:
                return Input.GetKey(KeyCode.Space);
        }
        return false;
    }

    public float Rotation()
    {
        switch (Device)
        {
            case InputDeviceType.XBoxController:
                //return Input.GetAxis("HorizontalTurn");

            case InputDeviceType.KeyboardAndMouse:
                return Input.GetAxis("Mouse X");
        }
        return 0.0f;
    }
}
