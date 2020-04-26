Lab2:

1. https://drive.google.com/file/d/1jm5tZwvc1yi4kVafbkX5BaZ12XC7s1iX/view?usp=sharing

2. ![](lab2/CatBunnyScrsht.png)

Lab3:

1.https://drive.google.com/open?id=1qJvG1p790rMQZbRrcGMnlnbkHe5YLtrI

2. Description of materials:

  a. Cube on the bottom left: This is a phong material with a specular highlight of green, from the Three.js default shaders/materials
  
  b. Torus knot in the center: this is the lab's provided fragment shader that changes the rgb value of the color based on the two provided colors and the z position of the current fragment
  
  c. The top right torus knot: Another one of the Three.js provided shaders, this is a toon shader with a specular highlight in white
  
  d. The orbiting torus knot: My custom shader, which uses the elapsed time since the program started as a uniform variable to change the color as the sin/cos of time (specifically: R = sin(-time) G = cos(time) B = sin^2(time)).

Lab 4:
Answers:
  a. x = u*8
  b. y = (1-v)*8
  c. (3,6) white
https://drive.google.com/open?id=1nHOejJ1jHoB9YiX3IAfbWAYOwnO-OiLs
Part 1 Texture A (uses three.js built in texture functionality) - used THREE.js built in texturing to add a flat texture
Part 1 Texture A & Normal Map A (uses three.js built in texture functionality) - used THREE.js build in texturing as well as THREE.js built i handling of normal maps to add surface texture without affecting geometry
Part 1 Texture B & Normal Map B (new texture/normal map combo using built in three.js functionality) - used THREE.js build in texturing as well as THREE.js built i handling of normal maps to add surface texture without affecting geometry
Part 2 Texture C (load this texture with shaders, as we worked through in the lab together) - used a sample2D uniform to apply a 2D texture to a cube via shader
Part 2 Texture D (tile this texture at least by showing a 2x2 grid) - multiplied the vUv uniform by 2, subtracted one to make sure that all of the tiles were sampling from the same place
