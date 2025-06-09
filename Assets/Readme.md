# Basketball Shooting Game (Unity)

## Objective
This is a simple 3D basketball shooting game built in Unity. The player shoots basketballs into a hoop, tries to score points, and sees feedback with an end game timer and score display.

## How to Run the Game
1. Open the provided Unity project in Unity Editor (version 2020.3 or later recommended).   
2. Use the mouse to aim and scroll the mouse wheel to adjust throw force.  
3. Click the left mouse button to shoot the ball.  
4. The timer counts down from 60 seconds, and your score is tracked and displayed.  
5. When time runs out, an end game panel appears with options to restart or exit.

## Controls
- **Mouse Movement:** Rotate the camera view (look around).  
- **Mouse Scroll Wheel:** Adjust the throw force of the basketball.  
- **Left Mouse Button Click:** Throw/shoot the basketball.  
- **Restart Button:** Restart the game after it ends.  
- **Exit Button:** Quit the game application.

## Code Structure Overview

### Core Scripts

- **ScoreManager.cs**  
  Manages the player's score, updates UI for score and timer, handles game timer countdown, shows end game UI, and manages game restart/exit.

- **UIForceControl.cs**  
  Controls the throw force slider UI and allows the player to adjust throw force using the mouse scroll wheel.

- **MouseLook.cs**  
  Handles camera rotation based on mouse input, locking/unlocking the cursor, and disabling camera control when the game ends.

- **BallControl.cs**  
  Controls the basketball behavior, including following the camera when held, shooting the ball with force, enabling gravity upon throw, and detecting collision with the ground to destroy the ball.

- **BallSpawner.cs**  
  Singleton class responsible for spawning new basketballs in front of the camera whenever a ball is destroyed.

- **HoopTrigger.cs**  
  Detects when the basketball passes through the hoop trigger area and increments the player's score via the ScoreManager.

## Game Workflow Summary

- The player views the scene through a controllable first-person camera (MouseLook).  
- The game starts with a basketball spawned in front of the camera (BallSpawner).  
- The ball follows the camera until the player clicks to throw it with a force adjustable by mouse scroll (UIForceControl + BallControl).  
- When the ball passes through the hoop collider (HoopTrigger), the score increments.  
- When the ball hits the ground, it is destroyed and a new ball is spawned automatically.  
- The ScoreManager tracks the game timer and score, updating the UI continuously.  
- Once the timer ends, the game shows an end panel with the final score and options to restart or quit.

## Additional Notes
- The cursor is locked and hidden during gameplay for immersive first-person control, but unlocked and visible when the game ends.  
- The throw force slider is synchronized with mouse scroll input to allow easy adjustment.  
- Score feedback ("COOL!") briefly appears each time the player scores.  
- The ball's physics and collision are managed to create realistic throwing and interaction with the environment.
