# PotHoleAlgorithm
 A program I wrote to find an algorithm for calculating the volume of water held in all potholes in a terrain, based on information about the terrain's elevation.

Take for example this terrain information:

![Demonstration](/demo.png)

The vertical axist represents the terrain elevation at position `i`.

`i` (the position on the terrain) is represented on the horizontal axis and is an integer greater than 0 and as large as the data type allows.

Elevation values are also integers, but they are greater or equal to zero and can go as high as the data type allows. Elevations are stored in an integer array that will be given as input. The array will have 0 or more elements.

When it rains, water is accumulated in the terrain. Any watter that is not in a "pothole", drains to the ground and can be considered as having 0 volume.

The requirement is to calculate the amount of water that accumulates in the potholes in the terrain.
