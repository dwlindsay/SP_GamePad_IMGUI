// Copyright 2026 Screen Play

*IMGUI Pseudocode for ps_GamePad GUI*


SPad placement on a PHONE  
┌───┬─┬───┐  
│   O   │  │   ┼   │  
└───┴─┴───┘  

SPad placement on a TABLET  
┌───────────┐  
│                             │    
├───┐        ┌───┤  
│   O   │       │   ┼   │  
└───┴───┴───┘  



```csharp

// Set Orientation to LANDSCAPE orientation
//                                               // Height: 4
//                                               // Width: 6

if (screen.height <= screen.width / 2)
{
    SPad.size = screen.height
} else {
    SPad.size = screen.height / 2;                // Size: 2
}
SPad.half = SPad.size / 2;                        // Half: 1

// Xa is X-All   // Xd is X-Draw  // Xt is X-Touch

SPad_L_orig.Xa = 0;                                // LorigXa: 0 = 0
SPad_L_orig.Yg = screen.height - SPad.size;        // LorigYg: 4-2 = 2
SPad_L_orig.Yt = screen.height - SPad_L_orig.Yg;   // LorigYt: 4-2 = 2

SPad_L_cent.Xa = SPad_L_orig.Xa + SPad.half;       // LcentXa: 0+1 = 1
SPad_L_cent.Yg = SPad_L_orig.Yg + SPad.half;       // LcentYg: 2+1 = 3
SPad_L_cent.Yt = screen.height - SPad_L_cent.Yg;   // LcentYt: 4-3 = 1

SPad_R_orig.Xa = screen.width - SPad.size;        // RorigXa: 6-2 = 4
SPad_R_orig.Yg = screen.height - SPad.size;       // RorigYg: 4-2 = 2
SPad_R_orig.Yt = screen.height - SPad_R_orig.Yg;  // RorigYt: 4-2 = 2

SPad_R_cent.Xa = screen.width - SPad.half;        // RcentXa: 6-1 = 5
SPad_R_cent.Yg = screen.height - SPad.half;       // RcentYg: 4-1 = 3
SPad_R_cent.Yt = screen.height - SPad_R_cent.Yg;  // Rcentt: 4-3 = 1

SPad_R_topR.Xa = SPad_R_orig.Xa + SPad.half;      // RtopXa: 4+1 = 5
SPad_R_topR.Yg = SPad_R_orig.Yg;                  // RtopYg: 2 = 2
SPad_R_topR.Yt = screen.height - SPad_R_topR.Yg;  // RtopYt: 4-2 = 2

SPad_R_botL.Xa = SPad_R_orig.Xa;                  // RbotXa: 4 = 4
SPad_R_botL.Yg = SPad_R_orig.Yg + SPad.half;      // RbotYg: 2+1 = 3
SPad_R_botL.Yt = screen.height - SPad_R_botL.Yg;  // RbotYt: 4-3 = 1

void OnGUI()
{
    GUI.Label(new Rect(10, 10, 200, 20), "Hello IMGUI");
    if (GUI.Button(new Rect(10, 40, 100, 30), "Click Me"))
    {
        Debug.Log("Button pressed");
    }
}


```

