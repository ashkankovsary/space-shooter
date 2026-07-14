# Space Shooter Game

A 2D top-down space shooter built in **C#** using **Windows Forms**, developed as the final project for the **Advanced Programming (AP)** course at university (second semester). The gameplay is heavily inspired by the classic arcade game **Chicken Invaders**.

## 📖 About

You pilot a spaceship through waves of enemies, dodging bullets and collisions while shooting down enemy ships to rack up score and coins. Along the way, power-ups drop from destroyed enemies to give you a temporary edge in battle.

## ✨ Features

- **Multiple enemy types**, each with unique behavior:
  - **Standard Enemy** – moves straight down the screen.
  - **Scout Enemy** – weaves side to side in a sine-wave pattern.
  - **Shooter Enemy** – periodically fires bullets at the player.
  - **Terrorist Enemy** – tracks and homes in on the player's position.
- **Power-up system**:
  - 🛡️ Shield – temporary invulnerability.
  - 🔫 Triple Shot – fires three bullets at once.
  - ⚡ Fire Rate Booster – doubles shooting speed.
  - ❤️ Health Pack – restores HP.
- **HP bars** for the player and active power-up timers, custom-drawn with a `Control`-based `HPbar` component.
- **Collision detection** between the player, enemies, bullets, and power-ups.
- **Pause menu** with resume/restart/exit options, rendered through a semi-transparent `OverlayPanel`.
- **Responsive UI** — the main menu dynamically rescales buttons and layout based on the window size.
- **Custom window management system** (`ManagedForm`) that synchronizes child form positions (e.g. the About window) with their parent form, including on move and resize.
- **Background music and sound effects** powered by `NAudio`, including distinct SFX for shooting, collisions, enemy destruction, power-up pickups, and UI clicks.

## 🎮 Controls

| Key | Action |
|-----|--------|
| `W` / `A` / `S` / `D` | Move the ship |
| `Space` | Shoot |
| `Esc` | Pause the game |

## 🏗️ Architecture

The game follows an **Object-Oriented Programming (OOP)** design:

- **`GameEntity`** — abstract base class for anything that moves and draws on screen (position, speed, collision radius).
- **`Combatant`** — abstract class extending `GameEntity` with HP and damage handling; base for both `Player` and `Enemy`.
- **`Enemy`** — abstract base class for all enemy types, extended by `StandardEnemy`, `ScoutEnemy`, `ShooterEnemy`, and `TerroristEnemy`.
- **`Player`** — handles movement, shooting, and power-up timers.
- **`Bullet`** / **`PowerUp`** — simple entities with their own movement and rendering logic.
- **`GameManager`** — the core game loop: updates entities, handles collisions, spawns power-up drops, and cleans up off-screen or destroyed objects.
- **`GameSettings`** — a centralized static class holding all tunable gameplay constants (speeds, HP, cooldowns, drop chances, etc.).
- **`ManagedForm`** — a custom `Form` base class that manages parent/child window relationships (used by `Form1`, `PlayForm`, and `AboutForm`).
- **`AudioManager`** — static class wrapping `NAudio` for background music and sound effect playback.

## 🛠️ Tech Stack

- **Language:** C#
- **Framework:** .NET Windows Forms (WinForms)
- **Audio:** NAudio
- **Data:** SQLite (for essential game data)
- **Paradigm:** Object-Oriented Programming (OOP)

## 👥 Authors

- Ashkan Kovsary — Std_ID: 404522034
- Ashkan Ehsani — Std_ID: 404521021

## 📄 License

This project was created for educational purposes as part of a university course assignment.
