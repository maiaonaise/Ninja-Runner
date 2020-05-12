# Ninja-Runner
Endless Ninja runner made in Unity. CMPM 151 Midterm project

Instructions:
1. To start the patch, open game_patch.pd and click the “Patch on/off switch” toggle. This will start the game music and pure-data will begin listening for OSC messages on port 8000.
2. To adjust the delay on the music loop, Adjust the “Delay_Feedback” and “Delay_Time_(milliseconds)” sliders.
3. Open the Unity game & collect coins. Press spacebar to jump.

When you collect coins the patch will make a “coin noise”. When you die, the patch will make a “death noise”. As your score increases, the tempo of the music loop will increase.