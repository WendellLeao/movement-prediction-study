# movement-prediction-study

A learning sandbox for client-side movement prediction and rollback networking, built on [FishNet](https://github.com/FirstGearGames/FishNet). The goal is to work through FishNet's prediction API hands-on: reconciliation, input replay, and state interpolation, starting from plain owner-authoritative movement and building up to a properly predicted controller.

This is an early scaffold, not a finished demo. Movement is currently a simple owner-driven `NetworkBehaviour` with no prediction or reconciliation yet; FishNet's prediction system is being introduced incrementally as the study progresses.

## Tech Stack

- **Engine:** Unity 6 (6000.6.0f1), Universal Render Pipeline
- **Networking:** [FishNet](https://github.com/FirstGearGames/FishNet), imported as source under `Assets/FishNet`
- **Input:** Unity Input System

## Project Structure

```
Assets/
├── _Project/
│   ├── Scenes/SampleScene.unity    # only scene; holds the NetworkManager
│   ├── Source/PlayerController.cs  # owner-driven movement (WASD), pre-prediction
│   ├── Prefabs/Player.prefab
│   └── Materials/
├── FishNet/                        # networking framework, imported as source (third-party)
└── Settings/                       # URP pipeline/renderer assets (default template)
```

`Assets/FishNet/Demos/Prediction` is kept around as a reference for prediction/rollback patterns while working through the framework.

## Status

Early scaffold: basic owner-authoritative movement over the network, no client-side prediction or reconciliation implemented yet.
