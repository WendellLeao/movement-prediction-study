# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Unity 6 (`6000.6.0f1`) URP project for studying client-side movement prediction / rollback networking with **FishNet** (`Assets/FishNet`, imported as source, not a package). The scene `Assets/Scenes/SampleScene.unity` has a `NetworkManager` GameObject wired up as the networking entry point.

This is one of the user's personal sandbox projects (`~/Documents/_Projects/Unity/Personal/`). It has no established architecture yet beyond a bare scaffold, so the `unity-clean-architecture` skill's conventions apply for new code here.

## Project Structure

- `Assets/_Project/Source/` — all project-specific C# code (currently just a stub `PlayerController`).
- `Assets/_Project/Prefabs/`, `Assets/_Project/Materials/` — project-specific assets.
- `Assets/FishNet/` — the FishNet networking framework, imported wholesale as source (not touched by project code; treat as third-party). Its `Demos/Prediction` folder is a useful reference for prediction/rollback patterns.
- `Assets/Scenes/SampleScene.unity` — the only scene; holds the `NetworkManager`.
- `Assets/Settings/` — URP pipeline/renderer assets (PC and Mobile variants) from the default Unity URP template.
- `Assets/TutorialInfo/` — leftover default Unity template readme/editor tooling, not project code.

## Working in Unity

There is no CLI build/lint/test pipeline set up in this repo; all iteration happens through the Unity Editor (Play mode) or the `unity-mcp-skill` MCP tools. Unity's built-in Test Framework package (`com.unity.test-framework`) is installed but no test assemblies exist yet.

Never hand-edit `.unity`, `.prefab`, `.asset`, or `.meta` files directly, always go through the Unity Editor or a Unity MCP tool.

## Collaboration Style

This project is the user's personal learning sandbox for client-side prediction. Default to an advisory role: explain concepts, review code, and suggest approaches, but do not implement code unless the user explicitly asks for it. When they do ask for an implementation, keep it as simple as the request calls for, and do not expand scope beyond what was asked.
