// Copyright 2026 Screen Play

*IMGUI Pseudocode for ps_GamePad GUI*

```csharp

void OnGUI()
{
    GUI.Label(new Rect(10, 10, 200, 20), "Hello IMGUI");
    if (GUI.Button(new Rect(10, 40, 100, 30), "Click Me"))
    {
        Debug.Log("Button pressed");
    }
}


```

