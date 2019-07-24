# GameOfBotHeroesVsMonsters

This is a project of mine which is supposed to be more of a test of the capabilites of Neural Networks and especially Genetic Algorithms.

This Project will be a kind of Simulation/Game in which a number of Agents in the way of Heroes fight make their way through the world and fight monsters and buy stuff in the towns from the money they get from the monsters.

The Heroes should have a Multi-Part-Brain in the way of multiple neural networks which I call AI for now:

Main-AI:
Controls which type of AI is suitable for the current situation

Travel-AI:
- Decides where to move next
- Gets all Directions and Values of the corresponding tiles it can see/move to

Speech-AI: (Not totally sure about it for now)
- Interacts with the other heroes
- Gets Information

Merchant-AI:
- Buys (and sells) in Stores
- Sees the Heroes Money
- Sees the Amount of each Item in its inventory

Combat-AI:
- Decides about the combat-tactic
- Sees its own life and the enemies life as well as damage and defense of each
- Can try to escape

----

World-Generation
- Size will be x*y
- Tile-based
- Procentual inputs of each Tile-Value (Towns, Forests, River (Water), etc)
- First all Tiles shall be given their Enum-Value and then everything shall be generated

- Set the amount of active Monsters
- Set the amount of active Heroes
-> Both types shall respawn if below a certain treshhold
-> The best Heroes shall have a chance of reproduction if they make it to the town

- Monsters give money to heroes upon death
- (Maybe make monsters AI-Controlled as well later on)

- Monsters reproduce over time (no matter of location)
- Heroes can reproduce over limit if they are capable to do so.

- Progress (or loss of it) in the AI of heroes happens when reproducing
-> New Random generated heroes spawn with [completly random neural networks | an average doing network](?)


