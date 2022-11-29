# space-shooter
Unity 2021.3.11f1

Space shooter with endless level. The player controls the spacecraft using the keyboard or joystick. 
You need to kill enemy ships and smash meteorites to get points. 
When colliding with meteorites or enemy lasers, lives are reduced. 
The player has at his disposal 3 types of weapons. 
Shooting with short laser beams ("bullets") occurs automatically at the same interval. They do little damage, their number is unlimited. 
The amount of damage, the frequency of shots and the speed of flight can be improved for coins in the store. 
Large laser beam: left control. Fires from the center of the ship and goes to the end of the screen in a continuous line. 
Has a limited duration, during which it deals damage every frame to enemies. Reloading takes a long time. 
Missiles: left alt. Quantity is limited, stocks are replenished in the store. When colliding with enemies, they deal high damage to all enemies within a certain radius. 
When destroying meteorites and killing enemies, a bonus can drop out: a pill restores health, a star doubles experience for a certain time, a shield protects against damage for a certain time, a magnet attracts coins to you. 
You can collect coins that appear on the screen, which can be spent on improvements (in development). 
The game has 4 slots for different players to save their progress. 
Saving the characteristics of players, their coins and records is carried out using serialization. 
During the game, when killing 5 enemy ships (or 10 meteorites), the difficulty increases: meteorites and enemies appear more often, they have more health, more speed, more damage. 
In development: leaderboards, interface color changes.
