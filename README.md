# space-shooter
Unity 2021.3.11f1

Space shooter with endless levels. The player controls the spacecraft using the keyboard or joystick.
You need to kill enemy ships and smash meteorites to get points.
When colliding with meteorites or enemy lasers, lives are reduced.
The player has 3 types of weapons.
Shooting with short laser beams ("bullets") occurs automatically at the same interval. They deal low damage and are unlimited in number.
The amount of damage, the frequency of shots and the flight speed can be improved for coins in the store.
Large laser beam: left control. Fires from the center of the ship and travels to the end of the screen in a continuous line.
Has a limited duration during which each frame deals damage to enemies. Reboot takes a long time.
Hurry, charge time and duration can be improved with coins in the store.
Missiles: left alt. Quantity is limited, stocks in the store are replenished. When colliding with enemies, they deal high damage to all enemies within a certain radius.
The damage dealt and the diameter of the explosion can be improved with coins in the store.
When destroying meteorites and killing enemies, a bonus may drop out: a pill restores health, a star doubles experience for a certain time, a shield protects against damage for a certain time, a magnet attracts coins to you.
The duration of time-limited bonuses (magnet, shield, doubling of experience) and the number of lives in a pill can be increased for coins in the store.
You can collect coins that appear on the screen, which can be spent on upgrades.
The game has 4 slots for different players to save their progress.
Each slot has its own color: red, blue, green, yellow. In accordance with this, the color of the interface and the player's ship changes.
Saving the characteristics of players, their coins and records is carried out using serialization.
During the game, when killing 5 enemy ships (or 10 meteorites), the difficulty increases: meteorites and enemies appear more often, they have more health, more speed, more damage.
