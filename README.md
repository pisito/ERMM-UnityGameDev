# ERMM-UnityGameDev
Repository for storing a common use source code to develop a game and its data structure.
I believe these repository represent a fundamental study for those who want to develop their own game.
This source code is simple and free of guarantee it will work perfectly. Please use it at your own risks. 

**Purpose**: The repository has been designed to kick-start learning experience in developing game module for everyone.
Currently, I maintain it manually. Any helping hand to operate the documentation will be grateful, feel free to contact me.

Contact me for collaboration or merge request if interested.
Author: Dr. Pisit Praiwattana
Email: pisit.pra@mahidol.edu
Repository: https://github.com/pisito/ERMM-UnityGameDev

For the structure of the repository, I will separate them into a major pack as following:

# General

Consists of the general data structure and controller often being seen in multiple instance of game in the market. It should serve as a prospective foundation to RAPID-PROTOTYPE the game demo.

## GenericData
 - Character
 - Stats
 - Level
 - Item
 - Inventory
 - EquipmentManager
 - Action
 - Scene
 - Achievement
 - Currency
 - Shop
 - QuestManager
 - GachaRandomManager
 - InputNewController
 - InputController
 -- Several ENUM specific for these sturcture
 + [Detection] often seen in the game
 + [GUIs] for generic purpose UI modification
 + [Items] an implementation of the specific <Item> class
 + [Actions] an implementation of the specific <Action> class
 + [Utility] an extension or useful functions for our generic data

## GenericController
 + [Player3D]
 + [Player2D]
 + [PlayerAI]

## GenericDemo
 
# FrameworkTool

It provides a specific tool or manager that mainly control the gameplay development. The usage can be complex and not all of them are required to be used together at the same time.

## Managers
 - ObjectPools
 - GameManager
 - WinLoseCondition
 - LocalMultiplayer
 - CinematicCamSwitcher
 - GameLevelManager
 - GameStatisticManager
 - TimeWrapperManager
 - SoundManager
 - VFXManager
 - DialogueManager
 - SaveLoadManager

# GameDemo

To make sure all of the components can be useful in developing game. We will provide a demo production utilizing our class and tool. These are prospective demo from our repository.

 - CollectCoin
 - TowerDefense
 - ShootingFPS
 - ShootingTopDownTwinStick
 - MOBA-2to6Local-Player
 - ArenaBattleRoyal
 - CardGameBattle
 - Puzzle
 - SandBoxSmallOpenWorld
 - StoryTellingVisualNovel
 - RPG

The wiki page will be updated over time.
