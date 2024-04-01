# ERMM-UnityGameDev
Repository for storing a common use source code to develop a game and its data structure. This source code is simple and free of guarantee it will work perfectly. Please use it at your own risks. 
Contact me for collaboration or merge request if interested.
Email: pisit.pra@mahidol.edu

# 1. Prospective Scope - GenericData

Basic Data Structure and Components to create a game
The initial version should cover these following requirements

**C-1 [Character]**

▪ Character package should have a component that defines a concept of character
▪ It should have a property to define identity commonly to everyone
▪ It should have a tag that define some occurrence of specific identity / property
▪ Is it a bard? Human? Goblin? Smart? Strong? WeaktoSomething? CanTalkToSnake?
▪ It should have a property to define numerical amount of health, magic, and stamina

**C-2 [Stats]**
▪ A concept of Stats should be developed to represent a numerical attribute of the
said character from previous story
▪ Strength can be abbreviated as [str]
▪ Intelligence as [int]
▪ Agility as [agi]
▪ Vitality as [vit]
▪ Magic as [mag]
▪ A character must have a representation of one Stats system

**C-3 [Level]**
▪ Character has Level and experience point. Each 100 percent of the experience
point contribute to a next level (Level up).
▪ Character now can have another system of stats that represent potential of the
growth of each stats per level
▪ You can go further by these following concepts:
▪ Character that has level up then reserve an attribute up currency that can invest on each
stat and receive a summative multiplier of growth up on investing them
▪ The Character then remembers how many investment had been invested up until the
current state
▪ Otherwise, character should have at least a favor/preference stat to have and can be
used as a default decision to invest upon Level up

**C-4 [Inventory] and [Item]**
▪ Each character a pocket of finite number space for an Inventory
▪ Each inventory hold a finite type of an item
▪ The character can picking/ drop/ and destroy and item out of the inventory
▪ An item can be a concept of thing with the quantity; however, it must have a
generic type to be categorized and filtered as needed by the inventory
▪ Go further by:
▪ Adding a concept of weight and maximum holding or stacking per an item type
▪ Weight Limit can be a limited property that calculated from a character stats

**C-5 [Equipment]**
▪ A Character may have an equipment slot that allow some of the item to be
equipped on these empty slots
▪ Equipment item then can provide additional modifying stats to the character or an
identity property tag
▪ Equipment slots then can be equipped/ unequipped freely unless something
blocking it
▪ Equipment item then can have its own identity tag if it is applicable
▪ A character might have different type of opened slots for equipment

**C-6 [Actions]**
▪ Action is an interaction that can occur in the game world
▪ It might have an actor as a character and the action might have or might not have
a target
▪ Action might have a requirement to use described as a [Requirement that
indicates conditional property/tag/status to use]
▪ Action might have a callback that occurred after execution
▪ A Character can be defined with a set of possible actions

**C-7 [Class]**
▪ A concept of a specific type of character with description of growth, property tags,
and specific action

**C-8 [Scene]**
▪ A concept setup that explain the location of specific character, item, and, [location
of interest]
▪ If you reached this point, congratulation!, you are quite diligent.
▪ It is about time to integrate this package / design / codes to the game component
to realize your first prototype
▪ The idea can be applied to 2D and 3D an even Text-driven game system
▪ Consult the class lecturer for direction in class : )

**C-9 [Multimedia Assets]**
- Multimedia assets involves graphical asset, audio, text, and video
- Develop a framework to have voice-over or voice-actor embedded in your component design
    - Audios
    - VFX Object
    - Text
    - Textures or specific file object that work the charm on your game component
 
**C-10 [Story]**
- Design a progression system that tailored the gameplay story
- Create an Episodic story telling with your game component
- Arc and Event Flags should be explored here

For now, these milestones will be a prospective requirements.

# 2. Prospective Scope - GenericController
The subsections should demonstrate the overall input handler to control the basic character either 2D, 3D, and with different genre as much as possible.
Here is the list of prospective module that should be added over time

Since Unity provides new input system, the implementation seems to become more complex over a logic to control character.
I suggested we strated from as basic as possible with the old input system as a template.
Then deliver an alternative folder with the new input system integration.

Old Input System Template
**PC-1 PlayerController3DRigidbody**
Basic Utility of movement in 3D world. Utilize a concept of Rigidbody
The instruction to setup in Unity scene should be documented or comment inside the code
    - Move with WASD with its front and right local space
    - Move with WASD with the camera's front and right perspective
    - An ability to control move speed with variety of mode of inputs
        - Walk (Slower than normal run)
        - Normal Run
        - Dash
    - An ability to Jump/doubleJump
    - An ability to Crouch
    - An ability to slowly rotate body of the visual character toward a movement direction
    - An ability to hold movement speed to zero (in place) then rotate its body toward a direction of WASD or mouse Input positions

