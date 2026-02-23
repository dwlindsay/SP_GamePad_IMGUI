// Copyright 2026 Screen Play

*IMGUI Pseudocode for ps_GamePad GUI*

```csharp

// Set Orientation to LANDSCAPE orientation

if (screen.height <= screen.width / 2)
{
    SPad.size = screen.height
} else {
    SPad.size = screen.height / 2;
}
SPad.half = SPad.size / 2;

// Xa is X-All   // Xd is X-Draw  // Xt is X-Touch

SPad_L_orig.Xa = 0;
SPad_L_orig.Yg = screen.height - SPad.size;
SPad_L_orig.Yt = screen.height - SPad_L_orig.Yg;

SPad_L_cent.Xa = SPad_L_orig.Xa + SPad.half;
SPad_L_cent.Yg = SPad_L_orig.Yg + SPad.half;
SPad_L_cent.Yt = screen.height - SPad_L_cent.Yg;

SPad_R_orig.Xa = screen.width - SPad.size;
SPad_R_orig.Yg = screen.height - SPad.size;
SPad_R_orig.Yt = screen.height - SPad_R_orig.Yg;

SPad_R_cent.Xa = screen.width - SPad.half;
SPad_R_cent.Yg = screen.height - SPad.half;
SPad_R_cent.Yt = screen.height - SPad_R_cent.Yg;

SPad_R_topR.Xa = SPad_R_orig.Xa + SPad.half;
SPad_R_topR.Yg = SPad_R_orig.Yg + SPad.half;
SPad_R_topR.Yt = screen.height - SPad_R_topR.Yg;

SPad_R_botL.Xa = SPad_R_orig.Xa;
SPad_R_botL.Yg = SPad_R_orig.Yg + SPad.half;
SPad_R_botL.Yt = screen.height - SPad_R_botL.Yg;

void OnGUI()
{
    GUI.Label(new Rect(10, 10, 200, 20), "Hello IMGUI");
    if (GUI.Button(new Rect(10, 40, 100, 30), "Click Me"))
    {
        Debug.Log("Button pressed");
    }
}


```

